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
        public decimal Totaux = 0;

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
                //if (Iadmin.EmailExisteDejaByClient(c))
                //{
                //    ModelState.AddModelError("", "L'adresse email existe déjà...");
                //    return View(c);
                //}
                //else
                //{ 

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
                var hc = new HistoriqueCommande();
                hc.idUtilisateur = c.idUtilisateur;
                hc.idCommande = com.idCommande;
                Iclient.AjoutertHistoriqueCommande(hc);
                Session["UtilisateurTemps"] = c.idUtilisateur;
                return RedirectToAction("CreerAdresse", "Adresse");
                //}
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
                var pc = new ProduitConsulte();
                pc.idProduit = p.idProduit;
                pc.idUtilisateur = Convert.ToInt32(Session["idUtilisateur"]);
                pc.DateConsultation = DateTime.Now;
                Iadmin.AjoutertProduitConsulte(pc);
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
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
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

        public ActionResult ConfirmationAdresse(int idUtilisateur)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var client = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                var commande = Iclient.TrouverCommandeById(client.idCommande);
                var LignesCommandes = Iadmin.ListerCommandeByPanier(commande.idCommande);
                foreach (var ldc in LignesCommandes)
                {
                    var p = Iclient.TrouverProduitById(ldc.idProduit);
                    if (ldc.Quantite > p.Stock )
                    {
                        var produit = Iclient.TrouverProduitById(ldc.idProduit);
                        Session["MessageQuantite01"] = "Nous sommes désolé mais notre stock du produit " + produit.NomProduit + " n'est pas siffussant pour répondre à votre demande.";
                        Session["MessageQuantite02"] = "Notre stock actuel pour le produit " + produit.NomProduit + " est de " + produit.Stock.ToString() + ".";
                        Session["MessageQuantite03"] = "Merci de bien vouloir modifier votre quantité afin de valider votre commande.";

                        return RedirectToAction("DetailPanier", "Client",new { id = ldc.idCommande});
                    }
                    Session["MessageQuantite01"] = "";
                    Session["MessageQuantite02"] = "";
                    Session["MessageQuantite03"] = "";
                }


                var res = Iclient.TrouverAdresseById(idUtilisateur);
                return View(res);

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult Paiement()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                
                var client = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                var commande = Iclient.TrouverCommandeById(client.idCommande);
                var LignesCommandes = Iadmin.ListerCommandeByPanier(commande.idCommande);
                if (commande.idStatut == 1)
                {
                    foreach (var ldc in LignesCommandes)
                    {
                        var p = Iclient.TrouverProduitById(ldc.idProduit);
                        p.Stock = p.Stock - ldc.Quantite;
                        Iadmin.ModifierProduit(p);
                        ldc.TotalLigneCommande = (ldc.Prix - (ldc.Prix * Convert.ToDecimal((ldc.PromotionProduit / 100)))) * ldc.Quantite;
                        Totaux = Totaux + (ldc.TotalLigneCommande - (ldc.TotalLigneCommande * Convert.ToDecimal(ldc.PromotionLigneCommande / 100)));
                    }

                commande.idStatut = 2;
                Iadmin.ModifierCommande(commande);

                var com = Iclient.AjouterCommande(new Commande());

                client.idCommande = com.idCommande;
                client.PointFidelite = client.PointFidelite + Convert.ToInt32(Totaux % 10);
                client.ConfirmationMotDePasse = client.MotDePasse;
                Iadmin.ModifierClient(client);

                var hc = new HistoriqueCommande();
                hc.idUtilisateur = client.idUtilisateur;
                hc.idCommande = com.idCommande;
                Iclient.AjoutertHistoriqueCommande(hc);

                }
                Totaux = 0;
                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AfficherValidationPanier(int id)
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var cli = Iclient.TrouverClientById(id);
                var a = Iclient.TrouverAdresseById(cli.idUtilisateur);
                var c = Iclient.TrouverCommandeById(cli.idCommande);
                ViewBag.Nom = cli.Nom;
                ViewBag.Prenom = cli.Prenom;
                ViewBag.Adresse01 = a.RueLigne01;
                ViewBag.Adresse02 = a.RueLigne02;
                ViewBag.Adresse03 = a.CodePostale;
                ViewBag.Adresse04 = a.Ville;
                ViewBag.Adresse05 = a.Pays;



                ICollection<CommandePanierModel> res = Iclient.ListerCommandeByPanier(cli.idCommande);
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult SuppClient()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2")
            {
                ICollection<Client> res = Iadmin.ListerClientSupp();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult DesactiverClient()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2")
            {
                ICollection<Client> res = Iadmin.ListeClientDesactiver();
                return View(res);
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult Desactivation(int id)
        {
            if (Session["idUtilisateur"] != null && (Session["idRole"].ToString() == "1" || Session["idRole"].ToString() == "2"))
            {
                var c = Iclient.TrouverClientById(id);
                Iadmin.DesactiverCompte(c);
                return RedirectToAction("ListerClient");
            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        // Envoi page SAV
        public ActionResult SAV()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }
        // Envoi page Livraison
        public ActionResult Livraison()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }
        // Envoi page Paiement
        public ActionResult Paiement_infos()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SendMail(string nom, string email, string message)
        {
            EMail OEmail = new EMail();
            try
            {
                OEmail.SendMail(email, "Contact : un message de " + nom, message, nom);
                ViewBag.message = "Merci ! Votre message a bien été envoyée.";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                ViewBag.message = "Merci ! Votre message a bien été envoyée.";
                return View();
            }
        }

        public ActionResult RechercherProduit()
        {
            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                return View();

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }


        public ActionResult ListeProduitByNom(string MotRecherche)
        {

            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {

                var res = Iclient.ListerProduitByMot(MotRecherche);
                return View(res);

            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

        public ActionResult AfficherProduitConsulte()
        {

            if (Session["idUtilisateur"] != null && Session["idRole"].ToString() == "3")
            {
                var cli = Iclient.TrouverClientById(Convert.ToInt32(Session["idUtilisateur"]));
                var res = Iclient.ListerProduitConsulteByClient(Convert.ToInt32(Session["idUtilisateur"]));
                ViewBag.titre = "Bonjour " + cli.Prenom + ", Nous sommes ravi de vous revoir parmis nous. Voici les produits que vous aviez consulté à votre dernière visite :";

                if(res.Count != 0)
                {
                return View(res);
                }
                else
                {
                    return View("indexClient");
                }


            }
            else
            {
                return RedirectToAction("Connexion", "Home");
            }
        }

    }
}