using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using TripPlanner_Construction.Entités;



namespace TripPlanner.web.Controllers
{
    public class LoginController : Controller
    {
        private TripPlannerContext _context;
        public LoginController(TripPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View("Login");
        }

        [HttpPost]
        public IActionResult Connexion(string utilisateur, string motdepasse)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("~/Home/Index");
            if (string.IsNullOrEmpty(utilisateur) || string.IsNullOrEmpty(motdepasse))
            {
                TempData["ko"] = "Veuillez saisir un utilisateur et un mot de passe";
                return Redirect("~/Login/Login");
            }

            Utilisateur u = _context.Utilisateurs.FirstOrDefault(ux => ux.Email == utilisateur);
            if (u != null)
            {

                if (motdepasse != u.MotDePasse)
                {
                    u = null;
                }
            }

            if (u == null)
            {
                TempData["ko"] = "Echec de lors de la connexion";
                return Redirect("~/Login/Login");
            }
            string claimRole = u.Role;

            var userClaims = new[] {
                        new Claim("Login", utilisateur),
                        new Claim("Role", claimRole) ,
                        new Claim(ClaimTypes.Name, utilisateur),//pour authorize
                       new Claim(ClaimTypes.Role, claimRole) ,//pour authorize
                        new Claim("Id", Convert.ToString(u.Id))
                   };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims, "custom");


            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });
            HttpContext.User = userPrincipal;
            HttpContext.SignInAsync(userPrincipal);

            HttpContext.Session.SetString("id", Convert.ToString(u.Id));
            HttpContext.Session.SetInt32("UtilisateurId", u.Id);
            HttpContext.Session.SetString("userName", utilisateur);
            HttpContext.Session.SetString("role", u.Role);
            TempData["ok"] = $"Bienvenue {utilisateur}";
            return RedirectToAction("Index", "Voyage");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(Utilisateur utilisateur)
        {
            if (string.IsNullOrEmpty(utilisateur.Nom) ||
                string.IsNullOrEmpty(utilisateur.Prenom) ||
                string.IsNullOrEmpty(utilisateur.Email) ||
                string.IsNullOrEmpty(utilisateur.MotDePasse))
            {
                TempData["ko"] = "Veuillez remplir tous les champs";
                return RedirectToAction("Register", "Login");
            }

            utilisateur.DateInscription = DateOnly.FromDateTime(DateTime.Now);
            utilisateur.Role = "Utilisateur";

            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();

            TempData["ok"] = "Compte créé avec succès";

            return RedirectToAction("Login", "Login");
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}










