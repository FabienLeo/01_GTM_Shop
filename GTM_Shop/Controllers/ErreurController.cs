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
    public class ErreurController : Controller
    {

        public IClient Iclient = new ClientImpl();


        public ActionResult Error404()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Error404(string MotRecherche)
        {
            ICollection<ProduitModel> res = Iclient.ListerProduitByMot(MotRecherche);
            return RedirectToAction("Index","Home");
        }
    }
}