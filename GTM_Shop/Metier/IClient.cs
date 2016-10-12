using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{
    public interface IClient
    {

        Utilisateur Connexion(Utilisateur u);

        ICollection<Abonnement> ListerAbonnement();

        Abonnement AjouterAbonnement(Abonnement a);

        ICollection<Abonnement> ListerAbonnementByNom(String MotRecherche);

        void ModifierAbonnement(Abonnement a);

        Abonnement TrouverAbonnementById(int id);

        void ModifierFacture(Facture f);

        bool SupprimerFacture(int id);

        Client AjouterClient(Client c);


        void ModifierClient(Client c);

        ICollection<Client> ListerClient();

        Client TrouverClientById(int id);

        ICollection<Client> ListerClientByNom(string nom);

        bool DemandeSuppCompte(int idClient);

        ProfilModel TrouverProfil(int id);

        Avis AjouterAvis(Avis a);

        AbonnementClient SouscrireAbonnement(Abonnement a, Client c);
        
        Commande AjouterCommande(Commande c);

        bool SupprimerCommande(int id);

        ICollection<CommandeModel> ListerCommande();

        LigneCommande TrouverLigneCommandeById(int id);

        ICollection<CommandePanierModel> ListerCommandeByPanier(int id);

        Panier TrouverPanierById(int id);

        Facture AjouterFacture(Facture f);

        Facture TrouverFactureById(int id);

        ICollection<Facture> ListerFacture();

        BonDeLivraison AjouterBonDeLivraison(BonDeLivraison bdl);

        BonDeLivraison TrouverBonDeLivraisonById(int id);

        ICollection<BonDeLivraison> ListerBonDeLivraison();

        void ModifierBonDeLivraison(BonDeLivraison bdl);

        void ModifierCommande(Commande c);

        Commande TrouverCommandeById(int id);

        bool SupprimerBonDeLivraison(int id);

        void EnvoyerEmail(Client c, string type);

        void AjouterPointFidelite(int idClient, Commande c);

        void PrintFacture(Facture f);

        void PrintBonDeLivraison(BonDeLivraison bdl);

        void Telechargerfacture(Facture f);

        void TelechargerBonDeLivraison(BonDeLivraison bdl);

        ICollection<Catalogue> ListerCatalogue();

        ICollection<Catalogue> ListerCatalogueByNom(string NomRecherche);

        Catalogue TrouverCatalogueById(int id);

        Produit AlerteStock(Produit p);

        ICollection<ProduitModel> ListerProduit();

        ICollection<ProduitModel> ListerProduitByMot(string MotRecherche);

        ICollection<ProduitModel> ListerProduitByCatalogue(int idCatalogue);

        ICollection<ProduitModel> ListerProduitByPromotion();

        Produit TrouverProduitById(int id);

        bool ModifierStock(int idProduit, int Quantite);

        Panier AjouterPanier(Panier p);

        void AjouterDansPanier(LigneCommande lc);

        void ModifierPanier(Panier p);

        LigneCommande AjouterLigneCommande(LigneCommande lc);


        void ModifierLigneCommande(LigneCommande lc);

        bool SupprimerLigneCommande(int id);

        ICollection<LigneCommande> ListerLigneCommande();

        Produit AfficherProduit(Produit P);

        ICollection<AvisClientProduitModel> ListerAvisByidProduit(int idProduit);

        Adresse TrouverAdresseById(int id);

        Adresse ModifierAdresse(Adresse a);

        Adresse TrouverAdresse(int id);

        Client TrouverProfilById(int id);

        Client ModifierProfil(Client c);

        Adresse AjouterAdresse(Adresse a);

        AdresseClient AjouterAdresseClient(AdresseClient adc);

    }
}
