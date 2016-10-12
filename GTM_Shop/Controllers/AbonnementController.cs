using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class AbonnementController : Controller
    {
        public IAdmin Iadmin = new AdminImpl();


        public ActionResult ListerAbonnement()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Abonnement> res = Iadmin.ListerAbonnement();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerAbonnement(string MotRecherche)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Abonnement> res = Iadmin.ListerAbonnementByNom(MotRecherche);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AjouterAbonnement()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult AjouterAbonnement(Abonnement a)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.AjouterAbonnement(a);
                    return RedirectToAction("ListerAbonnement");
                }
                else
                {
                    return View(a);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ModifierAbonnement(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Abonnement a = Iadmin.TrouverAbonnementById(id);
                return View(a);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierAbonnement(Abonnement a)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierAbonnement(a);
                    return RedirectToAction("ListerAbonnement");
                }
                else
                {
                    return View(a);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }


        public ActionResult SupprimerAbonnement(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerAbonnement(id);
                return RedirectToAction("ListerAbonnement");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

    }
}