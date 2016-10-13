using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class AvisController : Controller
    {
        public IClient Iclient = new ClientImpl();

        // GET: Avis
        public ActionResult AjouterAvis(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                Produit p = Iclient.TrouverProduitById(id);
                Session["idProduit"] = p.idProduit;
                ViewBag.NomProduit = p.NomProduit;
                ViewBag.Visuel = p.Visuel;
                var c = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                var a = new Avis();
                a.idProduit = p.idProduit;
                a.idUtilisateur = c.idUtilisateur;
                a.Produit = p;
                a.Client = c;
                a.NoteAvis = 1;
                return View(a);

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult AjouterAvis(Avis a)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                if (ModelState.IsValid)
                {
                    Iclient.AjouterAvis(a);
                    return RedirectToAction("AfficherProduit", "Client", new { id = a.idProduit });
                }
                else
                {
                    Produit p = Iclient.TrouverProduitById(a.idProduit);
                    Session["idProduit"] = p.idProduit;
                    ViewBag.NomProduit = p.NomProduit;
                    ViewBag.Visuel = p.Visuel;
                    return View(a);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }
    }
}