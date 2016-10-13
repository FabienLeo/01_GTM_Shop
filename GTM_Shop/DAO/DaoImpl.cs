using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTM_Shop.Metier;
using System.Data.Entity;
using GTM_Shop.Models;

namespace GTM_Shop.DAO
{


    public class DaoImpl : IDao
    {

        public Utilisateur Connexion(Utilisateur u)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                var req = bdd.Utilisateurs.FirstOrDefault((x => x.Email == u.Email && x.MotDePasse == u.MotDePasse));
                return req;
            }
        }



        public Administrateur AjouterAdmin(Administrateur a)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Administrateurs.Add(a);
                bdd.SaveChanges();
                return a;
            }
        }


        public ICollection<Administrateur> ListerAdmin()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Administrateurs.ToList();
            }
        }

        public Administrateur TrouverAdminById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Administrateurs.Find(id);
            }
        }

        public ICollection<Administrateur> ListerAdminByNom(string NomRecherche)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Administrateurs.Where(a => a.Nom.Contains(NomRecherche)).ToList();
            }
        }

        public void ModifierAdmin(Administrateur a)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(a).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }


        public ProfilModel TrouverProfil(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                var req = from ac in bdd.AdressesClients
                          join c in bdd.Clients
                          on ac.idUtilisateur equals id
                          join a in bdd.Adresses
                          on ac.idUtilisateur equals a.idAdresse
                          select new ProfilModel
                          {
                            idAdresse = a.idAdresse,
                            idUtilisateur = c.idUtilisateur,
                            Avatar = c.Avatar,
                            CiviliteClient = c.CiviliteClient,
                            Nom = c.Nom,
                            Prenom = c.Prenom,
                            DateDeNaissance = c.DateDeNaissance ,
                            RueLigne01 = a.RueLigne01 ,
                            RueLigne02 = a.RueLigne02,
                            CodePostale = a.CodePostale,
                            Ville = a.Ville,
                            Pays = a.Pays,
                            PointFidelite = c.PointFidelite
                            };
                return req.FirstOrDefault(x => x.idUtilisateur == id);
            }
        }

        public bool SupprimerAdmin(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Administrateur a = bdd.Administrateurs.Find(id);
                bdd.Administrateurs.Remove(a);
                bdd.SaveChanges();
                return true;
            }
        }

        public ICollection<Abonnement> ListerAbonnement()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Abonnements.ToList();
            }
        }

        public ICollection<Abonnement> ListerAbonnementByNom(String MotRecherche)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Abonnements.Where(a => a.NomAbonnement.Contains(MotRecherche)).ToList();
            }
        }

  

        public void ModifierAbonnement(Abonnement a)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(a).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public ICollection<Catalogue> ListerCatalogue()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Catalogues.ToList();
            }
        }

        public ICollection<Catalogue> ListerCatalogueByNom(string NomRecherche)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Catalogues.Where(c => c.NomCatalogue.Contains(NomRecherche)).ToList();
            }
        }

        public ICollection<ProduitModel> ListerProduit()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                var req = from p in bdd.Produits
                          join c in bdd.Catalogues
                          on p.idCatalogue equals c.idCatalogue
                          select new ProduitModel
                          {
                            idProduit = p.idProduit,
                            NomProduit = p.NomProduit,
                            Reference =p.Reference,
                            Prix =p.Prix,
                            PromotionProduit = p.PromotionProduit,
                            Stock =p.Stock,
                            Description =p.Description,
                            MoyenneNote = p.MoyenneNote,
                            Visuel =p.Visuel,
                            NomCatalogue= c.NomCatalogue
                        };
                return req.ToList();
            }
        }


        public Abonnement TrouverAbonnementById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Abonnements.Find(id);
            }
        }

        public Role TrouverRoleById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Roles.Find(id);
            }
        }

        public Role AjouterRole(Role r)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Roles.Add(r);
                bdd.SaveChanges();
                return r;
            }
        }

        public void ModifierRole(Role r)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(r).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public ICollection<Role> ListerRole()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Roles.ToList();
            }
        }

        public ICollection<Role> ListerRoleByNom(string NomRecherche)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Roles.Where(r => r.TypeRole.Contains(NomRecherche)).ToList();
            }
        }


        public bool SupprimerRole(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Role r = bdd.Roles.Find(id);
                bdd.Roles.Remove(r);
                bdd.SaveChanges();
                return true;
            }
        }

        public Avis AjouterAvis(Avis a)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Avis.Add(a);
                bdd.SaveChanges();
                return a;
            }
        }

        public Abonnement AjouterAbonnement(Abonnement a)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Abonnements.Add(a);
                bdd.SaveChanges();
                return a;
            }
        }



        public Catalogue AjouterCatalogue(Catalogue c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Catalogues.Add(c);
                bdd.SaveChanges();
                return c;
            }
        }

        public Client AjouterClient(Client c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Utilisateurs.Add(c);
                bdd.SaveChanges();
                return c;
            }
        }

        public Commande AjouterCommande(Commande c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                var fac = AjouterFacture(new Facture());
                var bdl = AjouterBonDeLivraison(new BonDeLivraison());
                c.idFacture = fac.idFacture;
                c.idBonDeLivraison = bdl.idBonDeLivraison;
                c.idStatut = 1;
                bdd.Commandes.Add(c);
                bdd.SaveChanges();
                return c;
            }
        }

        public ICollection<CommandePanierModel> ListerCommandeByPanier(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                var req = from ldc in bdd.LignesCommandes
                          join c in bdd.Commandes
                          on ldc.idCommande equals c.idCommande
                          join p in bdd.Produits
                          on ldc.idProduit equals p.idProduit
                          select new CommandePanierModel
                          {
                              idCommande = c.idCommande,
                              idLigneCommande = ldc.idLigneCommande,
                              Statut = c.Statut.Valeur,
                              Commentaire = c.Commentaire,
                              idFacture = c.idFacture,
                              idBonDeLivraison = c.idBonDeLivraison,
                              Quantite = ldc.Quantite,
                              PromotionLigneCommande = ldc.PromotionLigneCommande,
                              NomProduit = p.NomProduit,
                              Reference = p.Reference,
                              Prix = p.Prix,
                              PromotionProduit = p.PromotionProduit,
                              Visuel = p.Visuel,
                          };
                return req.ToList();
            }
        }

        public void AjouterDansPanier(LigneCommande lc)
        {
            throw new NotImplementedException();
        }

        public Produit AjouterProduit(Produit p)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Produits.Add(p);
                bdd.SaveChanges();
                return p;
            }
        }

        public LigneCommande AjouterLigneCommande(LigneCommande lc)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.LignesCommandes.Add(lc);
                bdd.SaveChanges();
                return lc;
            }
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

        public Panier AjouterPanier(Panier p)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                p.EstVide = true;
                bdd.Paniers.Add(p);
                bdd.SaveChanges();
                return p;
            }
        }
        

        public void EnvoyerEmail(Client c, string type)
        {
            throw new NotImplementedException();
        }

        public BonDeLivraison AjouterBonDeLivraison(BonDeLivraison bdl)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdl.NomDistributeur = "La Poste";
                bdd.BonsDeLivraisons.Add(bdl);
                bdd.SaveChanges();
                return bdl;
            }
        }

        public Facture AjouterFacture(Facture f)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Factures.Add(f);
                bdd.SaveChanges();
                return f;
            }
        }


        public ICollection<BonDeLivraison> ListerBonDeLivraison()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.BonsDeLivraisons.ToList();
            }
        }

        public ICollection<Client> ListerClient()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Clients.ToList();
            }
        }


        public ICollection<CommandeModel> ListerCommande()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                var req = from c in bdd.Commandes
                          join s in bdd.Statuts
                          on c.idStatut equals s.idStatut
                          orderby c.idCommande descending
                          select new CommandeModel
                          {
                              idCommande = c.idCommande,
                              Statut = s.Valeur,
                              idFacture = c.idFacture,
                              idBonDeLivraison = c.idBonDeLivraison,
                              Commentaire = c.Commentaire
                          };
                return req.ToList();
            }
        }

        public ICollection<Facture> ListerFacture()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Factures.ToList();
            }
        }

        public ICollection<LigneCommande> ListerLigneCommande()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.LignesCommandes.ToList();
            }
        }


        public void ModifierFacture(Facture f)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(f).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public void ModifierCatalogue(Catalogue c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(c).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public Catalogue TrouverCatalogueById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                return bdd.Catalogues.Find(id);
            }
        }

        public void ModifierClient(Client c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(c).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public void ModifierLigneCommande(LigneCommande lc)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(lc).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }


        public void ModifierPanier(Panier p)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(p).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }


        public void ModifierProduit(Produit p)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(p).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public void ModifierBonDeLivraison(BonDeLivraison bdl)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(bdl).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }


        public Commande TrouverCommandeById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.Commandes.Find(id);

            }
        }


        public LigneCommande TrouverLigneCommandeById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.LignesCommandes.Find(id);

            }
        }

        public Panier TrouverPanierById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.Paniers.Find(id);

            }
        }

        public void ModifierCommande(Commande c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Entry(c).State = EntityState.Modified;
                bdd.SaveChanges();
            }
        }

        public bool SupprimerBonDeLivraison(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                BonDeLivraison bdl = bdd.BonsDeLivraisons.Find(id);
                bdd.BonsDeLivraisons.Remove(bdl);
                bdd.SaveChanges();
                return true;
            }
        }
        
        public bool ModifierStatut(int idCommande, int idStatut)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Commande c = bdd.Commandes.Find(idCommande);
                c.idStatut = idStatut;
                bdd.SaveChanges();
                return true;
            }
        }

        public bool ModifierStock(int idProduit, int Quantite)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Produit p = bdd.Produits.Find(idProduit);
                p.Stock -= Quantite;
                bdd.SaveChanges();
                return true;
            }
        }


        public void PrintBonDeLivraison(BonDeLivraison bdl)
        {
            throw new NotImplementedException();
        }

        public void PrintFacture(Facture f)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProduitModel> ListerProduitByMot(string MotRecherche)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                var req = from p in bdd.Produits
                          join c in bdd.Catalogues
                          on p.idCatalogue equals c.idCatalogue
                          where p.NomProduit.Contains(MotRecherche)
                          select new ProduitModel
                          {
                              idProduit = p.idProduit,
                              NomProduit = p.NomProduit,
                              Reference = p.Reference,
                              Prix = p.Prix,
                              PromotionProduit = p.PromotionProduit,
                              Stock = p.Stock,
                              Description = p.Description,
                              MoyenneNote = p.MoyenneNote,
                              Visuel = p.Visuel,
                              NomCatalogue = c.NomCatalogue
                          };


                return req.ToList();


            }
        }

        public ICollection<ProduitModel> ListerProduitByCatalogue(int idCatalogue)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                var req = from p in bdd.Produits
                          join c in bdd.Catalogues
                          on p.idCatalogue equals c.idCatalogue
                          where p.idCatalogue.Equals(idCatalogue)
                          select new ProduitModel
                          {
                              idProduit = p.idProduit,
                              NomProduit = p.NomProduit,
                              Reference = p.Reference,
                              Prix = p.Prix,
                              PromotionProduit = p.PromotionProduit,
                              Stock = p.Stock,
                              Description = p.Description,
                              MoyenneNote = p.MoyenneNote,
                              Visuel = p.Visuel,
                              NomCatalogue = c.NomCatalogue
                          };


                return req.ToList();


            }
        }


        public ICollection<ProduitModel> ListerProduitByPromotion()
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                var req = from p in bdd.Produits
                          join c in bdd.Catalogues
                          on p.idCatalogue equals c.idCatalogue
                          where p.PromotionProduit > 0
                          select new ProduitModel
                          {
                              idProduit = p.idProduit,
                              NomProduit = p.NomProduit,
                              Reference = p.Reference,
                              Prix = p.Prix,
                              PromotionProduit = p.PromotionProduit,
                              Stock = p.Stock,
                              Description = p.Description,
                              MoyenneNote = p.MoyenneNote,
                              Visuel = p.Visuel,
                              NomCatalogue = c.NomCatalogue
                          };


                return req.ToList();


            }
        }

        public AbonnementClient SouscrireAbonnement(Abonnement a, Client c)
        {
            throw new NotImplementedException();
        }


        public bool SupprimerAbonnement(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Abonnement a = bdd.Abonnements.Find(id);
                bdd.Abonnements.Remove(a);
                bdd.SaveChanges();
                return true;
            }
        }




        public bool SupprimerFacture(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Facture f = bdd.Factures.Find(id);
                bdd.Factures.Remove(f);
                bdd.SaveChanges();
                return true;
            }
        }


        public bool SupprimerCatalogue(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Catalogue c = bdd.Catalogues.Find(id);
                bdd.Catalogues.Remove(c);
                bdd.SaveChanges();
                return true;
            }
        }


        public bool SupprimerClient(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Utilisateur c = bdd.Utilisateurs.Find(id);
                bdd.Utilisateurs.Remove(c);
                bdd.SaveChanges();
                return true;
            }
        }


        public bool SupprimerCommande(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Commande c = bdd.Commandes.Find(id);
                bdd.Commandes.Remove(c);
                bdd.SaveChanges();
                return true;
            }
        }


        public bool SupprimerLigneCommande(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                LigneCommande lc = bdd.LignesCommandes.Find(id);
                bdd.LignesCommandes.Remove(lc);
                bdd.SaveChanges();
                return true;
            }
        }


        public bool SupprimerProduit(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                Produit p = bdd.Produits.Find(id);
                bdd.Produits.Remove(p);
                bdd.SaveChanges();
                return true;
            }
        }

        public void TelechargerBonDeLivraison(BonDeLivraison bdl)
        {
            throw new NotImplementedException();
        }

        public void Telechargerfacture(Facture f)
        {
            throw new NotImplementedException();
        }

        public Client TrouverClientById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.Clients.Find(id);

            }
        }


        public ICollection<Client> ListerClientByNom(string NomRecherche)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.Clients.Where(p => p.Nom.Contains(NomRecherche)).ToList();

            }
        }


        public Facture TrouverFactureById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.Factures.Find(id);

            }
        }


        

        public BonDeLivraison TrouverBonDeLivraisonById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.BonsDeLivraisons.Find(id);

            }
        }

        public Produit TrouverProduitById(int id)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                return bdd.Produits.Find(id);

            }
        }

        public Produit AfficherProduit(Produit P)
        {
            using (var db = new DAO.GTM_Shop_Context())
            {
                return db.Produits.Find(P);
            }
        }

        public ICollection<AvisClientProduitModel> ListerAvisByidProduit(int idProduit)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {

                var req = from a in bdd.Avis
                          where a.idProduit == idProduit
                          join c in bdd.Clients
                          on a.idUtilisateur equals c.idUtilisateur
                          select new AvisClientProduitModel
                          {
                              idUtilisateur = c.idUtilisateur,
                              Prenom = c.Prenom,
                              TextAvis = a.TextAvis,
                              NoteAvis = a.NoteAvis,

                          };
                return req.ToList();

            }
        }

        public Adresse TrouverAdresseById(int id)
        {
            using (var bdd = new GTM_Shop_Context())
            {
                var req = from ac in bdd.AdressesClients
                          where ac.idUtilisateur == id
                          select ac;

                var idAd = req.FirstOrDefault().idAdresse;
                if (idAd == 0)
                {
                    return null;
                }
                else
                {

                    return bdd.Adresses.Find(idAd);
                }
            }
        }

        public Adresse TrouverAdresse(int id)
        {
            using (var bdd = new GTM_Shop_Context())
            {
                return bdd.Adresses.Find(id);
            }
        }

        public Adresse ModifierAdresse(Adresse a)
        {
            using (var bdd = new GTM_Shop_Context())
            {
                bdd.Entry(a).State = EntityState.Modified;
                bdd.SaveChanges();
                return a;
            }
        }

        public Client TrouverProfilById(int id)
        {
            using (var bdd = new GTM_Shop_Context())
            {
                return bdd.Clients.Find(id);
            }
        }
        public Client ModifierProfil(Client c)
        {
            using (var bdd = new GTM_Shop_Context())
            {
                bdd.Entry(c).State = EntityState.Modified;
                bdd.SaveChanges();
                return c;
            }
        }

        public Adresse AjouterAdresse(Adresse a)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.Adresses.Add(a);
                bdd.SaveChanges();
                return a;
            }
        }

        public AdresseClient AjouterAdresseClient(AdresseClient adc)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                bdd.AdressesClients.Add(adc);
                bdd.SaveChanges();
                return adc;
            }
        }

        public Client DemandeSuppCompte(Client c)
        {
            using (var bdd = new DAO.GTM_Shop_Context())
            {
                c.Compte_A_Supprimer = true;
                c.ConfirmationMotDePasse = c.MotDePasse;
                bdd.Entry(c).State = EntityState.Modified;
                bdd.SaveChanges();
                return c;
            }
        }
    }
}
