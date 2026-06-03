using Microsoft.AspNetCore.Mvc;
using TripPlanner_Construction.Entités;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner.web.Controllers
{
    public class VoyageController : Controller
    {
        private TripPlannerContext _context;
        public VoyageController(TripPlannerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string utilisateurSession = HttpContext.Session.GetString("id");

            if (utilisateurSession == null)
            {
                return RedirectToAction("Login", "Utilisateur");
            }

            int utilisateurId = int.Parse(utilisateurSession);

            var voyages = _context.Participations
                .Where(p => p.UtilisateurId == utilisateurId && p.EstActif)
                .Where(p => p.Voyage.EstActif)
                .Select(p => p.Voyage)
                .ToList();

            DateOnly aujourdHui = DateOnly.FromDateTime(DateTime.Today);

            foreach (var voyage in voyages)
            {
                if (voyage.DatelimiteVote < aujourdHui)
                {
                    voyage.StatutVote = "Fermé";
                }
                else
                {
                    voyage.StatutVote = "Ouvert";
                }
            }

            _context.SaveChanges();

            return View(voyages);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(Voyage v)
        {
            string sessionId = HttpContext.Session.GetString("id");

            if (sessionId == null)
            {
                return RedirectToAction("Login", "Login");
            }

            int utilisateurId = int.Parse(sessionId);

            v.Organisateurid = utilisateurId;
            v.EstActif = true;
            v.StatutVote = "Ouvert";

            _context.Voyages.Add(v);
            _context.SaveChanges();

            Participation participation = new Participation();
            participation.VoyageId = v.Id;
            participation.UtilisateurId = utilisateurId;
            participation.Role = "Organisateur";
            participation.EstActif = true;

            _context.Participations.Add(participation);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Voyage v = _context.Voyages.Find(id);
            if (v == null)
            {
                return NotFound();
            }

            return View(v);
           

        }
        [HttpPost]
        public IActionResult Edit(Voyage v)
        {
            var voyageDb = _context.Voyages.Find(v.Id);

            if (voyageDb == null)
            {
                return NotFound();
            }

            voyageDb.Destination = v.Destination;
            voyageDb.DateDebut = v.DateDebut;
            voyageDb.DateFin = v.DateFin;
            voyageDb.DatelimiteVote = v.DatelimiteVote;

            if (v.DatelimiteVote < DateOnly.FromDateTime(DateTime.Today))
            {
                voyageDb.StatutVote = "Fermé";
            }
            else
            {
                voyageDb.StatutVote = "Ouvert";
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }





        [HttpGet]
        public IActionResult Details(int id)
        {
            Voyage voyage = _context.Voyages
                .FirstOrDefault(v => v.Id == id && v.EstActif);

            if (voyage == null)
            {
                return NotFound();
            }

            ViewBag.Propositions = _context.Propositions
                .Where(p => p.VoyageId == id && p.EstActif)
                .ToList();
            ViewBag.Participations = _context.Participations
     .Include(p => p.Utilisateur)
     .Where(p => p.VoyageId == id && p.EstActif && p.Utilisateur.EstActif)
     .ToList();
            int utilisateurId = int.Parse(HttpContext.Session.GetString("id"));

            ViewBag.EstOrganisateur = voyage.Organisateurid == utilisateurId;
            ViewBag.UtilisateurId = utilisateurId;

            return View(voyage);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var voyage = _context.Voyages.Find(id);

            if (voyage == null)
            {
                return NotFound();
            }

            voyage.EstActif = false;

            var participations = _context.Participations
                .Where(p => p.VoyageId == id)
                .ToList();

            foreach (var participation in participations)
            {
                participation.EstActif = false;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    }
    