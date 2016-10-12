using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class CatalogueController : Controller
    {

        public IAdmin Iadmin = new AdminImpl();

        public ActionResult ListerCatalogue()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Catalogue> res = Iadmin.ListerCatalogue();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerCatalogue(string NomRecherche)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Catalogue> res = Iadmin.ListerCatalogueByNom(NomRecherche);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AjouterCatalogue()
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
        public ActionResult AjouterCatalogue(Catalogue c)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.AjouterCatalogue(c);
                    return RedirectToAction("ListerCatalogue");
                }
                else
                {
                    return View(c);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        
        public ActionResult ModifierCatalogue(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Catalogue c = Iadmin.TrouverCatalogueById(id);
                return View(c);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierCatalogue(Catalogue c)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierCatalogue(c);
                    return RedirectToAction("ListerCatalogue");
                }
                else
                {
                    return View(c);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }


        public ActionResult SupprimerCatalogue(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerCatalogue(id);
                return RedirectToAction("ListerCatalogue");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

    }
}