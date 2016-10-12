using GTM_Shop.Metier;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class CommandeController : Controller
    {

        public IAdmin Iadmin = new AdminImpl();

        public ActionResult DetailCommande(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                var c = Iadmin.TrouverCommandeById(id);
                ViewBag.idCommande = c.idCommande;
                ViewBag.idFacture = c.idFacture;
                ViewBag.idBonDeLivraison = c.idBonDeLivraison;
                ViewBag.idStatut = c.idStatut;

                ICollection<CommandePanierModel> res = Iadmin.ListerCommandeByPanier(id);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ModifierCommande(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Commande c = Iadmin.TrouverCommandeById(id);
                return View(c);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ModifierCommande(Commande c)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierCommande(c);
                    return RedirectToAction("IndexAdmin", "Administrateur");
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
    }
}