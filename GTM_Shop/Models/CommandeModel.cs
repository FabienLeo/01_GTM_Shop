using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTM_Shop.Models
{
    public class CommandeModel
    {
        [Display(Name = "Réf. Commande")]
        public int idCommande { get; set; }

        public StatutCommande Statut { get; set; }


        [Display(Name = "Réf. Facture")]
        public int idFacture { get; set; }

        [Display(Name = "Réf. BdL")]
        public int idBonDeLivraison { get; set; }

        public string Commentaire { get; set; }

    }
}