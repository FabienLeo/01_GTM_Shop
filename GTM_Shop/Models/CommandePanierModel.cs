using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTM_Shop.Models
{
    public class CommandePanierModel
    {
        [Display(Name = "Réf. Commande")]
        public int idCommande { get; set; }

        public int idLigneCommande { get; set; }

        public int idProduit { get; set; }

        public StatutCommande Statut { get; set; }

        public string Commentaire { get; set; }


        [Display(Name = "Réf. Facture")]
        public int idFacture { get; set; }

        [Display(Name = "Réf. BdL")]
        public int idBonDeLivraison { get; set; }

        [Display(Name = "Quantité")]
        public int Quantite { get; set; }

        [Display(Name = "%Promotion Commande")]
        public double PromotionLigneCommande { get; set; }

        [Display(Name = "Nom")]
        public string NomProduit { get; set; }

        [Display(Name = "Réf. fournisseur")]
        public string Reference { get; set; }

        public decimal Prix { get; set; }

        [Display(Name = "%Promotion Produit")]
        public double PromotionProduit { get; set; }

        public string Visuel { get; set; }

        public decimal TotalLigneCommande { get; set; }



    }
}