using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GTM_Shop.DAO
{
    public class GTM_Shop_Context : DbContext
    {

        public GTM_Shop_Context()
            : base("BDD_GTM_Shop")
        {

        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<Administrateur> Administrateurs { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Abonnement> Abonnements { get; set; }

        public DbSet<AbonnementClient> AbonnementClients { get; set; }

        public DbSet<Adresse> Adresses { get; set; }

        public DbSet<AdresseClient> AdressesClients { get; set; }

        public DbSet<Catalogue> Catalogues { get; set; }

        public DbSet<Produit> Produits { get; set; }

        public DbSet<Avis> Avis { get; set; }

        public DbSet<ProduitConsulte> ProduitsConsultes { get; set; }

        public DbSet<LigneCommande> LignesCommandes { get; set; }

        public DbSet<Commande> Commandes { get; set; }

        public DbSet<Facture> Factures { get; set; }

        public DbSet<BonDeLivraison> BonsDeLivraisons { get; set; }

        public DbSet<Panier> Paniers { get; set; }

        public DbSet<Statut> Statuts { get; set; }

        public DbSet<MoyenPaiement> MoyenPaiements { get; set; }
    }
}