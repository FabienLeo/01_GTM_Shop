using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class RoleController : Controller
    {

        public IAdmin Iadmin = new AdminImpl();

        public ActionResult ListerRole()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Role> res = Iadmin.ListerRole();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerRole(string NomRecherche)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Role> res = Iadmin.ListerRoleByNom(NomRecherche);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AjouterRole()
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
        public ActionResult AjouterRole(Role r)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.AjouterRole(r);
                    return RedirectToAction("ListerRole");
                }
                else
                {
                    return View(r);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ModifierRole(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Role r = Iadmin.TrouverRoleById(id);
                return View(r);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierRole(Role r)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierRole(r);
                    return RedirectToAction("ListerRole");
                }
                else
                {
                    return View(r);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }


        public ActionResult SupprimerRole(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerRole(id);
                return RedirectToAction("ListerRole");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }
    }
}