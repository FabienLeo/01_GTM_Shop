using GTM_Shop.DAO;
using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTM_Shop.Metier
{
    public class AdminImpl : IAdmin
    {
        public IDao Idao = new DaoImpl();

        public Administrateur AjouterAdmin(Administrateur a)
        {
            return Idao.AjouterAdmin(a);
        }

        public Catalogue AjouterCatalogue(Catalogue c)
        {
            return Idao.AjouterCatalogue(c);
        }

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

        public Produit AjouterProduit(Produit p)
        {
            return Idao.AjouterProduit(p);
        }

        public ICollection<CommandePanierModel> ListerCommandeByPanier(int id)
        {
            return Idao.ListerCommandeByPanier(id);
        }

        public LigneCommande AjouterLigneCommande(LigneCommande lc)
        {
            return Idao.AjouterLigneCommande(lc);
        }

        public void AjouterPointFidelite(int idClient, Commande c)
        {
            throw new NotImplementedException();
        }

        public Produit AlerteStock(Produit p)
        {
            throw new NotImplementedException();
        }

        public void CadeauAnniversaire(Client c)
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

        public ICollection<Administrateur> ListerAdmin()
        {
            return Idao.ListerAdmin();
        }

        public ICollection<Administrateur> ListerAdminByNom(string NomRecherche)
        {
            return Idao.ListerAdminByNom(NomRecherche);
        }

        public Administrateur TrouverAdminById(int id)
        {
            return Idao.TrouverAdminById(id);
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
        public Role AjouterRole(Role r)
        {
            return Idao.AjouterRole(r);
        }

        public Role TrouverRoleById(int id)
        {
            return Idao.TrouverRoleById(id);
        }

        public void ModifierRole(Role r)
        {
            Idao.ModifierRole(r);
        }

        public bool SupprimerRole(int id)
        {
            return Idao.SupprimerRole(id);
        }

        public ICollection<Role> ListerRole()
        {
            return Idao.ListerRole();
        }

        public ICollection<Role> ListerRoleByNom(string NomRecherche)
        {
            return Idao.ListerRoleByNom(NomRecherche);
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

        public void ModifierAdmin(Administrateur a)
        {
            Idao.ModifierAdmin(a);
        }

        public void ModifierCatalogue(Catalogue c)
        {
            Idao.ModifierCatalogue(c);
        }

        public void ModifierClient(Client c)
        {
            Idao.ModifierClient(c);
        }

        public void ModifierLigneCommande(LigneCommande lc)
        {
            Idao.ModifierLigneCommande(lc);
        }

        public void ModifierProduit(Produit p)
        {
            Idao.ModifierProduit(p);
        }

        public bool ModifierStatut(int idCommande, int idStatut)
        {
            return Idao.ModifierStatut(idCommande, idStatut);
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
        public bool SupprimerAbonnement(int id)
        {
           return Idao.SupprimerAbonnement(id);
        }

        public bool SupprimerAdmin(int id)
        {
            return Idao.SupprimerAdmin(id);
        }

        public bool SupprimerCatalogue(int id)
        {
            return Idao.SupprimerCatalogue(id);
        }

        public bool SupprimerClient(int id)
        {
            return Idao.SupprimerClient(id);
        }

        public bool SupprimerCommande(int id)
        {
            return Idao.SupprimerCommande(id);
        }

        public bool SupprimerLigneCommande(int id)
        {
            return Idao.SupprimerLigneCommande(id);
        }

        public bool SupprimerProduit(int id)
        {
            return Idao.SupprimerProduit(id);
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

    }
}