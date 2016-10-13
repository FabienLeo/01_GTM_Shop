using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{
    public interface IAdmin
    {

        Utilisateur Connexion(Utilisateur u);

        Administrateur AjouterAdmin(Administrateur a);

        ICollection<Administrateur> ListerAdmin();

        ICollection<Administrateur> ListerAdminByNom(string NomRecherche);

        Administrateur TrouverAdminById(int id);

        void ModifierAdmin(Administrateur a);

        bool SupprimerAdmin(int id);

        ICollection<Abonnement> ListerAbonnement();

        Abonnement AjouterAbonnement(Abonnement a);

        ICollection<Abonnement> ListerAbonnementByNom(String MotRecherche);

        void ModifierAbonnement(Abonnement a);

        Abonnement TrouverAbonnementById(int id);

        void ModifierFacture(Facture f);

        bool SupprimerFacture(int id);

        Role AjouterRole(Role r);

        ICollection<Role> ListerRole();

        ICollection<Role> ListerRoleByNom(string NomRecherche);

        Role TrouverRoleById(int id);

        void ModifierRole(Role r);

        bool SupprimerRole(int id);

        Client AjouterClient(Client c);


        void ModifierClient(Client c);

        ICollection<Client> ListerClient();

        Client TrouverClientById(int id);

        ICollection<Client> ListerClientByNom(string NomRecherche);

        bool SupprimerAbonnement(int id);

        void CadeauAnniversaire(Client c);

        bool SupprimerClient(int id);

        Commande AjouterCommande(Commande c);

        void ModifierCommande(Commande c);

        bool SupprimerCommande(int id);

        ICollection<CommandeModel> ListerCommande();

        bool ModifierStatut(int idCommande, int idStatut);

        ICollection<CommandePanierModel> ListerCommandeByPanier(int id);

        Facture AjouterFacture(Facture f);

        Facture TrouverFactureById(int id);

        ICollection<Facture> ListerFacture();

        BonDeLivraison AjouterBonDeLivraison(BonDeLivraison bdl);

        BonDeLivraison TrouverBonDeLivraisonById(int id);

        ICollection<BonDeLivraison> ListerBonDeLivraison();

        void ModifierBonDeLivraison(BonDeLivraison bdl);

        bool SupprimerBonDeLivraison(int id);

        Commande TrouverCommandeById(int id);

       // void ModifierCommande(Commande c);

        void EnvoyerEmail(Client c, string type);

        void AjouterPointFidelite(int idClient, Commande c);

        void PrintFacture(Facture f);

        void PrintBonDeLivraison(BonDeLivraison bdl);

        void Telechargerfacture(Facture f);

        void TelechargerBonDeLivraison(BonDeLivraison bdl);

        Produit AjouterProduit(Produit p);

        void ModifierProduit(Produit p);

        bool SupprimerProduit(int id);

        Catalogue AjouterCatalogue(Catalogue c);

        ICollection<Catalogue> ListerCatalogue();

        ICollection<Catalogue> ListerCatalogueByNom(string NomRecherche);

        Catalogue TrouverCatalogueById(int id);

        void ModifierCatalogue(Catalogue c);

        bool SupprimerCatalogue(int id);

        ICollection<ProduitModel> AlerteStock();

        ICollection<ProduitModel> ListerProduit();

        ICollection<ProduitModel> ListerProduitByMot(String MotRecherche);

        Produit TrouverProduitById(int id);


        LigneCommande AjouterLigneCommande(LigneCommande lc);


        void ModifierLigneCommande(LigneCommande lc);

        bool SupprimerLigneCommande(int id);

        ICollection<LigneCommande> ListerLigneCommande();

    }
}
