using Microsoft.AspNetCore.Mvc;
using TripPlanner_Construction.Entités;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner.Web.Controllers
{
    public class VoteController : Controller
    {
        private readonly TripPlannerContext _context;

        public VoteController(TripPlannerContext context)
        {
            _context = context;
        }

        public IActionResult Index(int voyageId)
        {
            Voyage voyage = _context.Voyages
                .FirstOrDefault(v => v.Id == voyageId);

            if (voyage == null)
            {
                return NotFound();
            }

            var propositions = _context.Propositions
                .Include(p => p.Votes)
                .Where(p => p.VoyageId == voyageId && p.EstActif)
                .ToList();

            ViewBag.Voyage = voyage;

            return View(propositions);
        }

        [HttpPost]
        public IActionResult Create(Vote vote, int voyageId)
        {
            int? utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");

            if (utilisateurId == null)
            {
                return RedirectToAction("Connexion", "Utilisateur");
            }

            bool dejaVote = _context.Votes.Any(v =>
                v.UtilsateurId == utilisateurId.Value &&
                v.PropositionId == vote.PropositionId);

            if (!dejaVote)
            {
                vote.UtilsateurId = utilisateurId.Value;
                vote.DateVote = DateOnly.FromDateTime(DateTime.Now);
                vote.EstActif = true;

                _context.Votes.Add(vote);
                _context.SaveChanges();

                RecalculerPropositionsRetenues(voyageId);
            }

            return RedirectToAction("Index", "Vote", new { voyageId = voyageId });
        }

        [HttpPost]
        public IActionResult RetirerVote(int propositionId, int voyageId)
        {
            int? utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");

            if (utilisateurId == null)
            {
                return RedirectToAction("Connexion", "Utilisateur");
            }

            var vote = _context.Votes.FirstOrDefault(v =>
                v.PropositionId == propositionId &&
                v.UtilsateurId == utilisateurId.Value);

            if (vote != null)
            {
                _context.Votes.Remove(vote);
                _context.SaveChanges();

                RecalculerPropositionsRetenues(voyageId);
            }

            return RedirectToAction("Index", "Vote", new { voyageId = voyageId });
        }
        [HttpPost]
        public IActionResult ConfirmerChoix(int voyageId)
        {
            List<Proposition> propositions = _context.Propositions
                .Where(p => p.VoyageId == voyageId)
                .ToList();

            foreach (Proposition proposition in propositions)
            {
                proposition.EstRetenue = false;
            }

            List<string> types = propositions
                .Select(p => p.TypeProposition)
                .Distinct()
                .ToList();

            foreach (string type in types)
            {
                Proposition propositionRetenue = propositions
                    .Where(p => p.TypeProposition == type)
                    .OrderByDescending(p => _context.Votes
                        .Count(v => v.PropositionId == p.Id))
                    .FirstOrDefault();

                if (propositionRetenue != null)
                {
                    propositionRetenue.EstRetenue = true;
                }
            }
           
            _context.SaveChanges();

            return RedirectToAction("Index",
                new { voyageId = voyageId });
        }

        private void RecalculerPropositionsRetenues(int voyageId)
        {
            var propositions = _context.Propositions
                .Where(p => p.VoyageId == voyageId && p.EstActif)
                .ToList();

            foreach (var proposition in propositions)
            {
                proposition.EstRetenue = false;
            }

            var groupes = propositions.GroupBy(p => p.TypeProposition);

            foreach (var groupe in groupes)
            {
                var classement = groupe
                    .Select(p => new
                    {
                        Proposition = p,
                        NombreVotes = _context.Votes.Count(v =>
                            v.PropositionId == p.Id &&
                            v.EstActif)
                    })
                    .OrderByDescending(x => x.NombreVotes)
                    .ToList();

                if (classement.Count > 0)
                {
                    int meilleurScore = classement[0].NombreVotes;

                    int nombreDeGagnants = classement.Count(x =>
                        x.NombreVotes == meilleurScore);

                    if (meilleurScore > 0 && nombreDeGagnants == 1)
                    {
                        classement[0].Proposition.EstRetenue = true;
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}