using GTM_Shop.Metier;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTM_Shop.Controllers
{
    public class ClientController : Controller
    {
        public IAdmin Iadmin = new AdminImpl();
        public IClient Iclient = new ClientImpl();

        public ActionResult IndexClient()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3" )
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerClient()
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Client> res = Iadmin.ListerClient();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ListerClient(string NomRecherche)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                ICollection<Client> res = Iadmin.ListerClientByNom(NomRecherche);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ModifierClient(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {

                Client c = Iadmin.TrouverClientById(id);
                return View(c);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierClient(Client c)
        {

            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                if (ModelState.IsValid)
                {
                    Iadmin.ModifierClient(c);
                    return RedirectToAction("ListerClient");
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


        public ActionResult SupprimerClient(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                Iadmin.SupprimerClient(id);
                return RedirectToAction("ListerClient");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ListerProdtuiByCatalogue(ICollection<ProduitModel> res)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerInformatique(int idCatalogue)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                ViewBag.titre = "Liste des produits informatiques";
                var res = Iclient.ListerProduitByCatalogue(idCatalogue);
                return View("ListerProdtuiByCatalogue", res);                 
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerImage(int idCatalogue)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                ViewBag.titre = "Liste des produits images";
                var res = Iclient.ListerProduitByCatalogue(idCatalogue);
                return View("ListerProdtuiByCatalogue", res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerSon(int idCatalogue)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                ViewBag.titre = "Liste des produits son";
                var res = Iclient.ListerProduitByCatalogue(idCatalogue);
                return View("ListerProdtuiByCatalogue", res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerTelephonie(int idCatalogue)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                ViewBag.titre = "Liste des produits telephonie";
                var res = Iclient.ListerProduitByCatalogue(idCatalogue);
                return View("ListerProdtuiByCatalogue", res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult ListerPromotion(int idCatalogue)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                ViewBag.titre = "Liste des produits en promotion";
                var res = Iclient.ListerProduitByPromotion();
                return View("ListerProdtuiByCatalogue", res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult CreerCompteClient()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreerCompteClient(Client c)
        {
            if (ModelState.IsValid)
            {
                if (Iadmin.EmailExisteDejaByClient(c))
                {
                    ModelState.AddModelError("", "L'adresse email existe déjà...");
                    return View(c);
                }
                else
                { 

                var com = Iclient.AjouterCommande(new Commande());
                c.Actif = true;
                c.Compte_A_Supprimer = false;
                c.PointFidelite = 0;
                c.idRole = 3;
                c.idMoyenPaiement = 1;
                c.idCommande = com.idCommande;
                if (c.SexeUtilisateur == 0)
                {
                    c.Avatar = "Avatar_Homme.png";
                }
                else
                {
                    c.Avatar = "Avatar_Femme.png";
                }

                Iclient.AjouterClient(c);
                Session["UtilisateurTemps"] = c.idUtilisateur;
                return RedirectToAction("CreerAdresse", "Adresse");
                }
            }
            else
            {
                return View(c);
            }

        }


        //Afficher un produit
        public ActionResult AfficherProduit(int id)
        {
            if(Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var p = Iclient.TrouverProduitById(id);
                ViewBag.NomProduit = p.NomProduit;
                ViewBag.Visuel = p.Visuel;
                ViewBag.Reference = p.Reference;
                ViewBag.Prix = p.Prix;
                ViewBag.Description = p.Description;
                ViewBag.idProduit = p.idProduit;
                ViewBag.PromotionProduit = p.PromotionProduit;
                IEnumerable<AvisClientProduitModel> res = Iclient.ListerAvisByidProduit(id);
                Session["idProduit"] = p.idProduit;             
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult AjouterDansPanier(int Quantite)
        {
            if(Quantite <= 0)
            {
                Session["Erreur"] = "La quantité ne peut pas être négative";
                return RedirectToAction("Afficherproduit", "Client", new { id = Convert.ToInt32(Session["idProduit"]) });
            }
            else
            {

            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                if (ModelState.IsValid && Quantite > 0)
                {
                    if (Session["idPanier"] != null)
                    {
                        var c = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                        var com = Iclient.TrouverCommandeById(c.idCommande);
                        var ldc_temp = new LigneCommande();
                        ldc_temp.idPanier = Convert.ToInt32(Session["idPanier"]);
                        ldc_temp.idCommande = com.idCommande;
                        ldc_temp.idProduit = Convert.ToInt32(Session["idProduit"]);
                        ldc_temp.Quantite = Quantite;
                        var ldc = Iclient.AjouterLigneCommande(ldc_temp);
                        Session["Erreur"] = "";
                        return RedirectToAction("DetailPanier", "Client", new { id = com.idCommande });
                        }
                    else
                    {
                        var c = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                        var com = Iclient.TrouverCommandeById(c.idCommande);
                        var panier = Iclient.AjouterPanier(new Panier());
                        var ldc_temp = new LigneCommande();
                        ldc_temp.idPanier = panier.idPanier;
                        ldc_temp.idCommande = com.idCommande;
                        ldc_temp.idProduit = Convert.ToInt32(Session["idProduit"]);
                        ldc_temp.Quantite = Quantite;
                        var ldc = Iclient.AjouterLigneCommande(ldc_temp);
                        Session["idPanier"] = panier.idPanier;
                        panier.EstVide = false;
                        Iclient.ModifierPanier(panier);
                        Session["Erreur"] = "";
                        return RedirectToAction("DetailPanier", "Client", new { id = com.idCommande });
                        }
                }
                else
                {
                    return RedirectToAction("Afficherproduit", "Client", new { id = Convert.ToInt32(Session["idProduit"]) });
                }

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
            }
        }

        public ActionResult AfficherPanier()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var c = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                int idCommande = c.idCommande;
                
                return RedirectToAction("DetailPanier", "Client", new { id = c.idCommande });

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult DetailPanier(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var c = Iclient.TrouverCommandeById(id);
                ViewBag.idCommande = c.idCommande;
                ViewBag.idStatut = c.idStatut;

                ICollection<CommandePanierModel> res = Iclient.ListerCommandeByPanier(id);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ModifierLigneCommande(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var lc = Iclient.TrouverLigneCommandeById(id);
                var p = Iclient.TrouverProduitById(lc.idProduit);
                ViewBag.Visuel = p.Visuel;
                ViewBag.NomProduit = p.NomProduit;
                ViewBag.prix = Convert.ToDouble(p.Prix);
                return View(lc);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        [HttpPost]
        public ActionResult ModifierLigneCommande(LigneCommande lc)
        {

            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                if (ModelState.IsValid)
                {
                    if (lc.Quantite == 0)
                    {
                        return RedirectToAction("SupprimerLigneCommande", new { id = lc.idLigneCommande});
                    }
                    else
                    {
                    Iclient.ModifierLigneCommande(lc);
                    return RedirectToAction("AfficherPanier");
                    }
                }
                else
                {
                    var p = Iclient.TrouverProduitById(lc.idProduit);
                    ViewBag.Visuel = p.Visuel;
                    ViewBag.NomProduit = p.NomProduit;
                    ViewBag.prix = Convert.ToDouble(p.Prix);
                    return View(lc);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult SupprimerLigneCommande(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                Iclient.SupprimerLigneCommande(id);
                return RedirectToAction("AfficherPanier");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }



     
        public ActionResult AfficherProfil()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                var res = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult AfficherAdresse(int idUtilisateur)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                var res = Iclient.TrouverAdresseById(idUtilisateur);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

     
        public ActionResult ModifierAdresse(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                Adresse a = Iclient.TrouverAdresse(id);
                return View(a);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModifierAdresse(Adresse a)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                if (ModelState.IsValid)
                {
                    Iclient.ModifierAdresse(a);
                    return RedirectToAction("AfficherAdresse", "Client", new { idUtilisateur = Convert.ToInt32(Session["idUtilisateur"]) });
                }
                else
                {
                    return View(a);
                }
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ModifierProfil(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                Client c = Iclient.TrouverProfilById(id);
                return View(c);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }

        }

        [HttpPost]
        public ActionResult ModifierProfil(Client c)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                
                if (ModelState.IsValid)
                {
                    Iclient.ModifierProfil(c);
                    return RedirectToAction("AfficherProfil");
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
        
        public ActionResult ConfirmerSuppression()
        {
            return View();
        }
        

       public ActionResult SuppressionConfirme(int idUtilisateur)
       {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var c = Iclient.TrouverClientById(idUtilisateur);
                Iclient.DemandeSuppCompte(c);
                Session["idUtilisateur"] = null;
                Session["Prenom"] = null;
                Session["idRole"] = null;
                return RedirectToAction("SuppressionDemandee");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ListerCommandeByIdClient(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                ICollection<CommandeModel> res = Iclient.ListerCommandeByIdClient(id);
                
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }



        public ActionResult SuppressionDemandee()
        {
            return View();
        }

    }
}