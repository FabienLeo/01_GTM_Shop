using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class BonDeLivraisonController : Controller
    {

        public IAdmin Iadmin = new AdminImpl();


        public ActionResult ListerBonDeLivraison()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<BonDeLivraison> res = Iadmin.ListerBonDeLivraison();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerBonDeLivraison(string id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                ICollection<BonDeLivraison> res = Iadmin.ListerBonDeLivraison();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }



        public ActionResult ModifierBonDeLivraison(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                BonDeLivraison bdl = Iadmin.TrouverBonDeLivraisonById(id);
                return View(bdl);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierBonDeLivraison(BonDeLivraison bdl)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierBonDeLivraison(bdl);
                    return RedirectToAction("ListerBonDeLivraison");
                }
                else
                {
                    return View(bdl);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }


        public ActionResult SupprimerBonDeLivraison(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerBonDeLivraison(id);
                return RedirectToAction("ListerBonDeLivraison");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

    }
}