using GTM_Shop.Metier;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class ProduitController : Controller
    {

        public IAdmin Iadmin = new AdminImpl();

        public ActionResult ListerProduit()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<ProduitModel> res = Iadmin.ListerProduit();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerProduit(string MotRecherche)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<ProduitModel> res = Iadmin.ListerProduitByMot(MotRecherche);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AjouterProduit()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                ViewBag.idCatalogue = new SelectList(Iadmin.ListerCatalogue(), "idCatalogue", "NomCatalogue");
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult AjouterProduit(Produit p)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.AjouterProduit(p);
                    return RedirectToAction("ListerProduit");
                }
                else
                {
                    ViewBag.idCatalogue = new SelectList(Iadmin.ListerCatalogue(), "idCatalogue", "NomCatalogue");
                    return View(p);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ModifierProduit(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Produit p = Iadmin.TrouverProduitById(id);
                ViewBag.idCatalogue = new SelectList(Iadmin.ListerCatalogue(), "idCatalogue", "NomCatalogue");
                return View(p);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierProduit(Produit p)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierProduit(p);
                    ViewBag.idCatalogue = new SelectList(Iadmin.ListerCatalogue(), "idCatalogue", "NomCatalogue");
                    return RedirectToAction("ListerProduit");
                }
                else
                {
                    ViewBag.idCatalogue = new SelectList(Iadmin.ListerCatalogue(), "idCatalogue", "NomCatalogue");
                    return View(p);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }


        public ActionResult SupprimerProduit(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerProduit(id);
                return RedirectToAction("ListerProduit");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }
        // lister produits faible quantité - alerte stock
        public ActionResult AlerteStock()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<ProduitModel> res = Iadmin.AlerteStock();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

    }
}
