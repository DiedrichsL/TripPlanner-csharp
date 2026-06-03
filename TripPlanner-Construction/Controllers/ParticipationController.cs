using Microsoft.AspNetCore.Mvc;
using TripPlanner_Construction.Entités;

namespace TripPlanner.Web.Controllers
{
    public class ParticipationController : Controller
    {
        private readonly TripPlannerContext _context;

        public ParticipationController(TripPlannerContext context)
        {
            _context = context;
        }

        public IActionResult Index(int voyageId)
        {
            ViewBag.VoyageId = voyageId;

            var participations = _context.Participations
                .Where(p => p.VoyageId == voyageId)
                .ToList();

            return View(participations);
        }

        [HttpPost]
        public IActionResult AjouterParticipant(int utilisateurId, int voyageId)
        {
            Participation participation = _context.Participations
                .FirstOrDefault(p =>
                    p.VoyageId == voyageId &&
                    p.UtilisateurId == utilisateurId);

            if (participation == null)
            {
                participation = new Participation();

                participation.VoyageId = voyageId;
                participation.UtilisateurId = utilisateurId;
                participation.EstActif = true;

                _context.Participations.Add(participation);
            }
            else
            {
                participation.EstActif = true;
            }

            _context.SaveChanges();

            return RedirectToAction("Details",
                "Voyage",
                new { id = voyageId });
        }

        [HttpPost]
        public IActionResult Create(int VoyageId, string Email)
        {
            Utilisateur utilisateur = _context.Utilisateurs
                .FirstOrDefault(u => u.Email == Email);

            if (utilisateur == null)
            {
                TempData["ErreurParticipant"] =
                    "Aucun utilisateur avec cette adresse mail.";

                return RedirectToAction("Details",
                    "Voyage",
                    new { id = VoyageId });
            }

            Participation participation = _context.Participations
                .FirstOrDefault(p =>
                    p.VoyageId == VoyageId &&
                    p.UtilisateurId == utilisateur.Id);

            
            if (participation != null && participation.EstActif)
            {
                TempData["ErreurParticipant"] =
                    "Cet utilisateur participe déjà au voyage.";

                return RedirectToAction("Details",
                    "Voyage",
                    new { id = VoyageId });
            }

          
            if (participation != null)
            {
                participation.EstActif = true;
            }
            else
            {
                participation = new Participation();

                participation.VoyageId = VoyageId;
                participation.UtilisateurId = utilisateur.Id;
                participation.Role = "Participant";
                participation.EstActif = true;

                _context.Participations.Add(participation);
            }

            _context.SaveChanges();

            return RedirectToAction("Details",
                "Voyage",
                new { id = VoyageId });
        }


        [HttpPost]
        public IActionResult QuitterVoyage(int voyageId)
        {
            int utilisateurId = int.Parse(HttpContext.Session.GetString("id"));

            Participation participation = _context.Participations
                .FirstOrDefault(p => p.VoyageId == voyageId
                                  && p.UtilisateurId == utilisateurId
                                  && p.EstActif);

            if (participation == null)
            {
                return RedirectToAction("Index", "Voyage");
            }

            participation.EstActif = false;
            _context.SaveChanges();

            return RedirectToAction("Index", "Voyage");
        }


        [HttpPost]
        public IActionResult RetirerParticipant(int participationId, int voyageId)
        {
            Participation participation = _context.Participations
                .FirstOrDefault(p => p.Id == participationId);

            if (participation == null)
            {
                return RedirectToAction("Details", "Voyage", new { id = voyageId });
            }

            participation.EstActif = false;

            _context.SaveChanges();

            return RedirectToAction("Details", "Voyage", new { id = voyageId });
        }
    }
}
