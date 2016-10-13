using GTM_Shop.Metier;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class HomeController : Controller
    {
        public IAdmin Iadmin = new AdminImpl();
        public IClient Iclient = new ClientImpl();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Connexion(Utilisateur u)
        {
            var UtilisateurActif = Iadmin.Connexion(u);

            if (UtilisateurActif != null)
            {
                Session["idUtilisateur"] = UtilisateurActif.idUtilisateur;
                Session["Prenom"] = UtilisateurActif.Prenom;
                Session["idRole"] = UtilisateurActif.idRole;

                if (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2")
                {
                    return RedirectToAction("IndexAdmin", "Administrateur");
                }
                else if (Session["idRole"].ToString() == "3")
                {
                    // if (u.Actif == true)
                    return RedirectToAction("IndexClient", "Client");
                    // else
                    // Session["idUtilisateur"] = null;
                    // Session["Prenom"] = null;
                    // Session["idRole"] = null;
                    // return RedirectToAction("CompteInactif", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "L'adresse email ou le mot de passe sont incorrecte");
                return View();
            }
        }

        public ActionResult Deconnexion()
        {
            Session["idUtilisateur"] = null;
            Session["Prenom"] = null;
            Session["idRole"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult ListerProdtuiByCatalogue(ICollection<ProduitModel> res)
        {
            return View(res);
        }

        public ActionResult ListerInformatique(int idCatalogue)
        {
            ViewBag.titre = "Liste des produits informatiques";
            var res = Iclient.ListerProduitByCatalogue(idCatalogue);
            return View("ListerProdtuiByCatalogue", res);
        }

        public ActionResult ListerImage(int idCatalogue)
        {
            ViewBag.titre = "Liste des produits images";
            var res = Iclient.ListerProduitByCatalogue(idCatalogue);
            return View("ListerProdtuiByCatalogue", res);
        }
        public ActionResult ListerSon(int idCatalogue)
        {
            ViewBag.titre = "Liste des produits son";
            var res = Iclient.ListerProduitByCatalogue(idCatalogue);
            return View("ListerProdtuiByCatalogue", res);
        }
        public ActionResult ListerTelephonie(int idCatalogue)
        {
            ViewBag.titre = "Liste des produits telephonie";
            var res = Iclient.ListerProduitByCatalogue(idCatalogue);
            return View("ListerProdtuiByCatalogue", res);
        }

        public ActionResult ListerPromotion(int idCatalogue)
        {
            ViewBag.titre = "Liste des produits en promotion";
            var res = Iclient.ListerProduitByPromotion();
            return View("ListerProdtuiByCatalogue", res);
        }


        //Afficher un produit
        public ActionResult AfficherProduit(int id)
        {
            var p = Iclient.TrouverProduitById(id);
            ViewBag.NomProduit = p.NomProduit;
            ViewBag.Visuel = p.Visuel;
            ViewBag.Reference = p.Reference;
            ViewBag.Prix = p.Prix;
            ViewBag.Description = p.Description;
            IEnumerable<AvisClientProduitModel> res = Iclient.ListerAvisByidProduit(id);
            return View(res);
        }

    }
}