namespace GTM_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationBDD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbonnementClients",
                c => new
                    {
                        idAbonnement = c.Int(nullable: false),
                        idUtilisateur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idAbonnement, t.idUtilisateur })
                .ForeignKey("dbo.Abonnements", t => t.idAbonnement, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.idUtilisateur, cascadeDelete: true)
                .Index(t => t.idAbonnement)
                .Index(t => t.idUtilisateur);
            
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        idAbonnement = c.Int(nullable: false, identity: true),
                        NomAbonnement = c.String(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        PrixAbonnement = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.idAbonnement);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        idUtilisateur = c.Int(nullable: false, identity: true),
                        SexeUtilisateur = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        MotDePasse = c.String(nullable: false),
                        Avatar = c.String(),
                        idRole = c.Int(nullable: false),
                        Actif = c.Boolean(),
                        CiviliteClient = c.Int(),
                        DateDeNaissance = c.DateTime(),
                        PointFidelite = c.Int(),
                        Compte_A_Supprimer = c.Boolean(),
                        idCommande = c.Int(),
                        idMoyenPaiement = c.Int(),
                        Profession = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idUtilisateur)
                .ForeignKey("dbo.Commandes", t => t.idCommande, cascadeDelete: true)
                .ForeignKey("dbo.MoyenPaiements", t => t.idMoyenPaiement, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.idRole, cascadeDelete: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.idRole)
                .Index(t => t.idCommande)
                .Index(t => t.idMoyenPaiement);
            
            CreateTable(
                "dbo.Avis",
                c => new
                    {
                        idProduit = c.Int(nullable: false),
                        idUtilisateur = c.Int(nullable: false),
                        NoteAvis = c.Double(nullable: false),
                        TextAvis = c.String(),
                    })
                .PrimaryKey(t => new { t.idProduit, t.idUtilisateur })
                .ForeignKey("dbo.Utilisateurs", t => t.idUtilisateur, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.idProduit, cascadeDelete: true)
                .Index(t => t.idProduit)
                .Index(t => t.idUtilisateur);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        idProduit = c.Int(nullable: false, identity: true),
                        NomProduit = c.String(nullable: false),
                        Reference = c.String(nullable: false),
                        Prix = c.Decimal(nullable: false, storeType: "money"),
                        Stock = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        MoyenneNote = c.Double(nullable: false),
                        PromotionProduit = c.Double(nullable: false),
                        idCatalogue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProduit)
                .ForeignKey("dbo.Catalogues", t => t.idCatalogue, cascadeDelete: true)
                .Index(t => t.idCatalogue);
            
            CreateTable(
                "dbo.Catalogues",
                c => new
                    {
                        idCatalogue = c.Int(nullable: false, identity: true),
                        NomCatalogue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idCatalogue);
            
            CreateTable(
                "dbo.LigneCommandes",
                c => new
                    {
                        idLigneCommande = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        PromotionLigneCommande = c.Double(nullable: false),
                        idProduit = c.Int(nullable: false),
                        idCommande = c.Int(nullable: false),
                        idPanier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLigneCommande)
                .ForeignKey("dbo.Commandes", t => t.idCommande, cascadeDelete: true)
                .ForeignKey("dbo.Paniers", t => t.idPanier, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.idProduit, cascadeDelete: true)
                .Index(t => t.idProduit)
                .Index(t => t.idCommande)
                .Index(t => t.idPanier);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        idCommande = c.Int(nullable: false, identity: true),
                        Commentaire = c.String(nullable: false),
                        idFacture = c.Int(nullable: false),
                        idBonDeLivraison = c.Int(nullable: false),
                        idStatut = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCommande)
                .ForeignKey("dbo.BonDeLivraisons", t => t.idBonDeLivraison, cascadeDelete: true)
                .ForeignKey("dbo.Factures", t => t.idFacture, cascadeDelete: true)
                .ForeignKey("dbo.Statuts", t => t.idStatut, cascadeDelete: true)
                .Index(t => t.idFacture)
                .Index(t => t.idBonDeLivraison)
                .Index(t => t.idStatut);
            
            CreateTable(
                "dbo.BonDeLivraisons",
                c => new
                    {
                        idBonDeLivraison = c.Int(nullable: false, identity: true),
                        NomDistributeur = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idBonDeLivraison);
            
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        idFacture = c.Int(nullable: false, identity: true),
                        TVA = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idFacture);
            
            CreateTable(
                "dbo.Statuts",
                c => new
                    {
                        idStatut = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idStatut);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        idPanier = c.Int(nullable: false, identity: true),
                        EstVide = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPanier);
            
            CreateTable(
                "dbo.ProduitConsultes",
                c => new
                    {
                        idProduit = c.Int(nullable: false),
                        idUtilisateur = c.Int(nullable: false),
                        DateConsultation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProduit, t.idUtilisateur })
                .ForeignKey("dbo.Utilisateurs", t => t.idUtilisateur, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.idProduit, cascadeDelete: true)
                .Index(t => t.idProduit)
                .Index(t => t.idUtilisateur);
            
            CreateTable(
                "dbo.AdresseClients",
                c => new
                    {
                        idUtilisateur = c.Int(nullable: false),
                        idAdresse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idUtilisateur, t.idAdresse })
                .ForeignKey("dbo.Adresses", t => t.idAdresse, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.idUtilisateur, cascadeDelete: true)
                .Index(t => t.idUtilisateur)
                .Index(t => t.idAdresse);
            
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        idAdresse = c.Int(nullable: false, identity: true),
                        RueLigne01 = c.String(nullable: false),
                        RueLigne02 = c.String(nullable: false),
                        CodePostale = c.String(nullable: false),
                        Ville = c.String(nullable: false),
                        Pays = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idAdresse);
            
            CreateTable(
                "dbo.MoyenPaiements",
                c => new
                    {
                        idMoyenPaiement = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMoyenPaiement);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        idRole = c.Int(nullable: false, identity: true),
                        TypeRole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRole);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilisateurs", "idRole", "dbo.Roles");
            DropForeignKey("dbo.Utilisateurs", "idMoyenPaiement", "dbo.MoyenPaiements");
            DropForeignKey("dbo.AdresseClients", "idUtilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.AdresseClients", "idAdresse", "dbo.Adresses");
            DropForeignKey("dbo.AbonnementClients", "idUtilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.ProduitConsultes", "idProduit", "dbo.Produits");
            DropForeignKey("dbo.ProduitConsultes", "idUtilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.LigneCommandes", "idProduit", "dbo.Produits");
            DropForeignKey("dbo.LigneCommandes", "idPanier", "dbo.Paniers");
            DropForeignKey("dbo.Commandes", "idStatut", "dbo.Statuts");
            DropForeignKey("dbo.LigneCommandes", "idCommande", "dbo.Commandes");
            DropForeignKey("dbo.Commandes", "idFacture", "dbo.Factures");
            DropForeignKey("dbo.Utilisateurs", "idCommande", "dbo.Commandes");
            DropForeignKey("dbo.Commandes", "idBonDeLivraison", "dbo.BonDeLivraisons");
            DropForeignKey("dbo.Produits", "idCatalogue", "dbo.Catalogues");
            DropForeignKey("dbo.Avis", "idProduit", "dbo.Produits");
            DropForeignKey("dbo.Avis", "idUtilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.AbonnementClients", "idAbonnement", "dbo.Abonnements");
            DropIndex("dbo.AdresseClients", new[] { "idAdresse" });
            DropIndex("dbo.AdresseClients", new[] { "idUtilisateur" });
            DropIndex("dbo.ProduitConsultes", new[] { "idUtilisateur" });
            DropIndex("dbo.ProduitConsultes", new[] { "idProduit" });
            DropIndex("dbo.Commandes", new[] { "idStatut" });
            DropIndex("dbo.Commandes", new[] { "idBonDeLivraison" });
            DropIndex("dbo.Commandes", new[] { "idFacture" });
            DropIndex("dbo.LigneCommandes", new[] { "idPanier" });
            DropIndex("dbo.LigneCommandes", new[] { "idCommande" });
            DropIndex("dbo.LigneCommandes", new[] { "idProduit" });
            DropIndex("dbo.Produits", new[] { "idCatalogue" });
            DropIndex("dbo.Avis", new[] { "idUtilisateur" });
            DropIndex("dbo.Avis", new[] { "idProduit" });
            DropIndex("dbo.Utilisateurs", new[] { "idMoyenPaiement" });
            DropIndex("dbo.Utilisateurs", new[] { "idCommande" });
            DropIndex("dbo.Utilisateurs", new[] { "idRole" });
            DropIndex("dbo.Utilisateurs", new[] { "Email" });
            DropIndex("dbo.AbonnementClients", new[] { "idUtilisateur" });
            DropIndex("dbo.AbonnementClients", new[] { "idAbonnement" });
            DropTable("dbo.Roles");
            DropTable("dbo.MoyenPaiements");
            DropTable("dbo.Adresses");
            DropTable("dbo.AdresseClients");
            DropTable("dbo.ProduitConsultes");
            DropTable("dbo.Paniers");
            DropTable("dbo.Statuts");
            DropTable("dbo.Factures");
            DropTable("dbo.BonDeLivraisons");
            DropTable("dbo.Commandes");
            DropTable("dbo.LigneCommandes");
            DropTable("dbo.Catalogues");
            DropTable("dbo.Produits");
            DropTable("dbo.Avis");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Abonnements");
            DropTable("dbo.AbonnementClients");
        }
    }
}
