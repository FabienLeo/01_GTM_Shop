using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class FactureController : Controller
    {
        public IAdmin Iadmin = new AdminImpl();


        public ActionResult ListerFacture()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Facture> res = Iadmin.ListerFacture();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerFacture(string id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                ICollection<Facture> res = Iadmin.ListerFacture();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }



        public ActionResult ModifierFacture(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Facture f = Iadmin.TrouverFactureById(id);
                return View(f);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierFacture(Facture f)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierFacture(f);
                    return RedirectToAction("ListerFacture");
                }
                else
                {
                    return View(f);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }


        public ActionResult SupprimerFacture(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerFacture(id);
                return RedirectToAction("ListerFacture");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

    }
}