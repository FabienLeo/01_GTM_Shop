using GTM_Shop.DAO;
using GTM_Shop.Metier;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class AdministrateurController : Controller
    {

        public IAdmin Iadmin = new AdminImpl();

        public ActionResult IndexAdmin()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                ICollection<CommandeModel> res = Iadmin.ListerCommande();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion","Home");
            }
        }


        [HttpPost]
        public ActionResult IndexAdmin(string id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                int idCommande = Convert.ToInt32(id);
                Commande c = Iadmin.TrouverCommandeById(idCommande);

                if (c != null)
                {
                    return RedirectToAction("DetailCommande", "Commande", new { id = c.idCommande });
                }
                else
                {
                    var res = Iadmin.ListerCommande();
                    return View("IndexAdmin", res);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerAdministrateur()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Administrateur> res = Iadmin.ListerAdmin();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerAdministrateur(string NomRecherche)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Administrateur> res = Iadmin.ListerAdminByNom(NomRecherche);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AjouterAdmin()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ViewBag.idRole = new SelectList(Iadmin.ListerRole(), "idRole", "TypeRole");
                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult AjouterAdmin(Administrateur a)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.AjouterAdmin(a);
                    return RedirectToAction("ListerAdministrateur");
                }
                else
                {
                    ViewBag.idRole = new SelectList(Iadmin.ListerRole(), "idRole", "TypeRole");
                    return View(a);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ModifierAdmin(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Administrateur a = Iadmin.TrouverAdminById(id);
                ViewBag.idRole = new SelectList(Iadmin.ListerRole(), "idRole", "TypeRole");
                return View(a);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierAdmin(Administrateur a)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierAdmin(a);
                    return RedirectToAction("ListerAdministrateur");
                }
                else
                {
                    ViewBag.idRole = new SelectList(Iadmin.ListerRole(), "idRole", "TypeRole");
                    return View(a);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
            
        }


        public ActionResult SupprimerAdmin(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
            Iadmin.SupprimerAdmin(id);
            return RedirectToAction("ListerAdministrateur");
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
                    return RedirectToAction("IndexAdministrateur");
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