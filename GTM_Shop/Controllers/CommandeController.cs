using GTM_Shop.Metier;
using GTM_Shop.Models;
using Rotativa.MVC;
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
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2" || Session["idRole"].ToString() == "3"))
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


        //Création d'un fichier pdf
        public ActionResult PrintInvoice(int id)
        {
            string NomFichier = "Facture_" + id + ".pdf";
            return new ActionAsPdf(
                           "RecapitulatifCommande", new { idCommande = id })
            { FileName = NomFichier };
        }

        public ActionResult RecapitulatifCommande(int idCommande)
        {
            var c = Iadmin.ListerCommandeByPanier(idCommande);
            var com = Iadmin.TrouverCommandeById(idCommande);
            ViewBag.idCommande = com.idCommande;
            ViewBag.idFacture = com.idFacture;
            ViewBag.idBonDeLivraison = com.idBonDeLivraison;
            ViewBag.idStatut = com.idStatut;

            var cli = Iadmin.TrouverClientById(Iadmin.TrouverClientByIdCommande(idCommande));

            var a = Iadmin.TrouverAdresseById(cli.idUtilisateur);

            ViewBag.NomClient = cli.Nom;
            ViewBag.PrenomClient = cli.Prenom;
            ViewBag.Ligne01 = a.RueLigne01;
            ViewBag.Ligne02 = a.RueLigne02;
            ViewBag.CodePostale = a.CodePostale;
            ViewBag.Ville = a.Ville;
            ViewBag.Pays = a.Pays;


            return View(c);
        }


    }
}