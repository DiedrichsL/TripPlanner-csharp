using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TripPlanner_Construction.Entités;

namespace TripPlanner.web.Controllers
{
    public class PropositionController : Controller
    {

        private TripPlannerContext _context;

        public PropositionController(TripPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int voyageId)
        {
            var proposition = new Proposition();
            proposition.VoyageId = voyageId;

            return View(proposition);
        }

        [HttpPost]

        [HttpPost]
        public IActionResult Create(Proposition proposition)
        {
            int utilisateurId = int.Parse(HttpContext.Session.GetString("id"));

            proposition.UtilisateurId = utilisateurId;
            proposition.EstActif = true;

            _context.Propositions.Add(proposition);
            _context.SaveChanges();

            return RedirectToAction("Details", "Voyage", new { id = proposition.VoyageId });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Proposition p = _context.Propositions
                .FirstOrDefault(p => p.Id == id);

            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Proposition proposition)
        {
            Proposition p1 = _context.Propositions
                .Find(proposition.Id);

            p1.Titre = proposition.Titre;
            p1.Description = proposition.Description;
            p1.TypeProposition = proposition.TypeProposition;

            _context.Propositions.Update(p1);

            _context.SaveChanges();

            return RedirectToAction("Details", "Voyage",
                new { id = p1.VoyageId });
        }

        [HttpPost]
        public IActionResult SupprimerProposition(int propositionId, int voyageId)
        {
            string sessionId = HttpContext.Session.GetString("id");

            if (sessionId == null)
            {
                return RedirectToAction("Login", "Login");
            }

            int utilisateurId = int.Parse(sessionId);

            Proposition proposition = _context.Propositions
                .FirstOrDefault(p => p.Id == propositionId && p.EstActif);

            if (proposition == null)
            {
                return RedirectToAction("Details", "Voyage", new { id = voyageId });
            }

            Voyage voyage = _context.Voyages
                .FirstOrDefault(v => v.Id == voyageId && v.EstActif);

            if (voyage == null)
            {
                return RedirectToAction("Index", "Voyage");
            }

            if (proposition.UtilisateurId == utilisateurId || voyage.Organisateurid == utilisateurId)
            {
                proposition.EstActif = false;
                _context.SaveChanges();
            }

            return RedirectToAction("Details", "Voyage", new { id = voyageId });
        }
    }
}
