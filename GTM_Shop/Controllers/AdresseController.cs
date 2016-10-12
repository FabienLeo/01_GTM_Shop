using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class AdresseController : Controller
    {
        public IClient Iclient = new ClientImpl();
        // GET: Adresse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreerAdresse()
        {
            if (Session["UtilisateurTemps"] != null )
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreerAdresse(Adresse a)
        {
            if (ModelState.IsValid)
            {
                Iclient.AjouterAdresse(a);
                var ac = new AdresseClient();
                ac.idAdresse = a.idAdresse;
                ac.idUtilisateur = Convert.ToInt32(Session["UtilisateurTemps"]);
                Iclient.AjouterAdresseClient(ac);
                return RedirectToAction("Connexion", "Home");
            }
            else
            {
                return View(a);
            }

        }


    }
}