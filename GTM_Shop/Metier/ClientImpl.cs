using GTM_Shop.DAO;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTM_Shop.Metier
{
    public class ClientImpl : IClient
    {
        public IDao Idao = new DaoImpl();


        public Catalogue TrouverCatalogueById(int id)
        {
            return Idao.TrouverCatalogueById(id);
        }


        public Client AjouterClient(Client c)
        {
            return Idao.AjouterClient(c);
        }

        public Commande AjouterCommande(Commande c)
        {
            return Idao.AjouterCommande(c);
        }

        public LigneCommande AjouterLigneCommande(LigneCommande lc)
        {
            return Idao.AjouterLigneCommande(lc);
        }

        public ICollection<CommandePanierModel> ListerCommandeByPanier(int id)
        {
            return Idao.ListerCommandeByPanier(id);
        }

        public Panier TrouverPanierById(int id)
        {
            return Idao.TrouverPanierById(id);
        }

        public void AjouterPointFidelite(int idClient, Commande c)
        {
            throw new NotImplementedException();
        }

        public Produit AlerteStock(Produit p)
        {
            throw new NotImplementedException();
        }

        public Utilisateur Connexion(Utilisateur u)
        {
            return Idao.Connexion(u);
        }

        public void EnvoyerEmail(Client c, string type)
        {
            throw new NotImplementedException();
        }

        public BonDeLivraison AjouterBonDeLivraison(BonDeLivraison bdl)
        {
            return Idao.AjouterBonDeLivraison(bdl);
        }

        public Facture AjouterFacture(Facture f)
        {
            return Idao.AjouterFacture(f);
        }

        public ICollection<Abonnement> ListerAbonnement()
        {
            return Idao.ListerAbonnement();
        }

        public Abonnement AjouterAbonnement(Abonnement a)
        {
            return Idao.AjouterAbonnement(a);
        }

        public ICollection<Abonnement> ListerAbonnementByNom(String MotRecherche)
        {
            return Idao.ListerAbonnementByNom(MotRecherche);
        }

        public void ModifierAbonnement(Abonnement a)
        {
            Idao.ModifierAbonnement(a);
        }

        public Abonnement TrouverAbonnementById(int id)
        {
            return Idao.TrouverAbonnementById(id);
        }

        public ICollection<Catalogue> ListerCatalogue()
        {
            return Idao.ListerCatalogue();
        }

        public ICollection<Catalogue> ListerCatalogueByNom(string NomRecherche)
        {
            return Idao.ListerCatalogueByNom(NomRecherche);
        }

        public ICollection<BonDeLivraison> ListerBonDeLivraison()
        {
            return Idao.ListerBonDeLivraison();
        }

        public ICollection<Client> ListerClient()
        {
            return Idao.ListerClient();
        }

        public ProfilModel TrouverProfil(int id)
        {
            return Idao.TrouverProfil(id);
        }

        public ICollection<CommandeModel> ListerCommande()
        {
            return Idao.ListerCommande();
        }

        public ICollection<ProduitModel> ListerProduit()
        {
            return Idao.ListerProduit();
        }

        public ICollection<Facture> ListerFacture()
        {
            return Idao.ListerFacture();
        }

        public ICollection<LigneCommande> ListerLigneCommande()
        {
            return Idao.ListerLigneCommande();
        }

        public void ModifierClient(Client c)
        {
            Idao.ModifierClient(c);
        }

        public void ModifierLigneCommande(LigneCommande lc)
        {
            Idao.ModifierLigneCommande(lc);
        }

        public void ModifierBonDeLivraison(BonDeLivraison bdl)
        {
            Idao.ModifierBonDeLivraison(bdl);
        }

        public bool SupprimerBonDeLivraison(int id)
        {
            return Idao.SupprimerBonDeLivraison(id);
        }

        public void PrintBonDeLivraison(BonDeLivraison bdl)
        {
            throw new NotImplementedException();
        }

        public void PrintFacture(Facture f)
        {
            throw new NotImplementedException();
        }

        public void ModifierFacture(Facture f)
        {
            Idao.ModifierFacture(f);
        }

        public bool SupprimerFacture(int id)
        {
            return Idao.SupprimerFacture(id);
        }

        public bool SupprimerCommande(int id)
        {
            return Idao.SupprimerCommande(id);
        }

        public bool SupprimerLigneCommande(int id)
        {
            return Idao.SupprimerLigneCommande(id);
        }

        public void TelechargerBonDeLivraison(BonDeLivraison bdl)
        {
            throw new NotImplementedException();
        }

        public void Telechargerfacture(Facture f)
        {
            throw new NotImplementedException();
        }

        public BonDeLivraison TrouverBonDeLivraisonById(int id)
        {
            return Idao.TrouverBonDeLivraisonById(id);
        }

        public Commande TrouverCommandeById(int id)
        {
            return Idao.TrouverCommandeById(id);
        }

        public void ModifierCommande(Commande c)
        {
            Idao.ModifierCommande(c);
        }

        public Client TrouverClientById(int id)
        {
            return Idao.TrouverClientById(id);
        }

        public ICollection<Client> ListerClientByNom(string NomRecherche)
        {
            return Idao.ListerClientByNom(NomRecherche);
        }

        public Facture TrouverFactureById(int id)
        {
            return Idao.TrouverFactureById(id);
        }

        public Produit TrouverProduitById(int id)
        {
            return Idao.TrouverProduitById(id);
        }

        public ICollection<ProduitModel> ListerProduitByMot(string MotRecherche)
        {
            return Idao.ListerProduitByMot(MotRecherche);
        }

        public bool DemandeSuppCompte(int idClient)
        {
            return Idao.DemandeSuppCompte(idClient);
        }

        public Avis AjouterAvis(Avis a)
        {
            return Idao.AjouterAvis(a);
        }

        public AbonnementClient SouscrireAbonnement(Abonnement a, Client c)
        {
            throw new NotImplementedException();
        }

        public bool ModifierStock(int idProduit, int Quantite)
        {
            return Idao.ModifierStock(idProduit, Quantite);
        }

        public Panier AjouterPanier(Panier p)
        {
            return Idao.AjouterPanier(p);
        }

        public void AjouterDansPanier(LigneCommande lc)
        {
            Idao.AjouterDansPanier(lc);
        }

        public void ModifierPanier(Panier p)
        {
            Idao.ModifierPanier(p);
        }

        public ICollection<ProduitModel> ListerProduitByCatalogue(int idCatalogue)
        {
            return Idao.ListerProduitByCatalogue(idCatalogue);
        }

        public ICollection<ProduitModel> ListerProduitByPromotion()
        {
            return Idao.ListerProduitByPromotion();
        }

        public Produit AfficherProduit(Produit P)
        {
            return Idao.AfficherProduit(P);
        }

        public LigneCommande TrouverLigneCommandeById(int id)
        {
            return Idao.TrouverLigneCommandeById(id);
        }

        public ICollection<AvisClientProduitModel> ListerAvisByidProduit(int idProduit)
        {
            return Idao.ListerAvisByidProduit(idProduit);
        }

        public Adresse TrouverAdresseById(int id)
        {
            return Idao.TrouverAdresseById(id);
        }

        public Adresse ModifierAdresse(Adresse a)
        {
            return Idao.ModifierAdresse(a);
        }

        public Adresse TrouverAdresse(int id)
        {
            return Idao.TrouverAdresse(id);
        }

        public Client TrouverProfilById(int id)
        {
            return Idao.TrouverProfilById(id);
        }
        public Client ModifierProfil(Client c)
        {
            return Idao.ModifierProfil(c);
        }

        public Adresse AjouterAdresse(Adresse a)
        {
            return Idao.AjouterAdresse(a);
        }

        public AdresseClient AjouterAdresseClient(AdresseClient adc)
        {
            return Idao.AjouterAdresseClient(adc);
        }

        public ICollection<CommandeModel> ListerCommandeByIdClient(int id)
        {
            return Idao.ListerCommandeByIdClient(id);
        }
    }
}