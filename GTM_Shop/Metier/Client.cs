using GTM_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Client : Utilisateur
    {

        [Required]
        public bool Actif { get; set; }

        [Required]
        [Display(Name = "Civilité")]
        public Civilite CiviliteClient { get; set; }

        [Required(ErrorMessage = "Une date de naissance est obligatoire")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DateRangeNaissance(ErrorMessage = "Votre age doit être compris entre 12 et 99 ans")]
        public DateTime DateDeNaissance { get; set; }

        [Required]
        [Display(Name = "Point Fidélité")]
        public int PointFidelite { get; set; }

        [Required]
        [Display(Name = "Compte A Supprimer")]
        public bool Compte_A_Supprimer { get; set; }

        public virtual ICollection<Avis> Avis { get; set; }

        public virtual ICollection<ProduitConsulte> ProduitsConsultes { get; set; }

        public int idCommande { get; set; }

        //public virtual Commande Commande { get; set; }

        public virtual ICollection<AdresseClient> ClientsAdresses { get; set; }

        public virtual ICollection<AbonnementClient> ClientsAbonnements { get; set; }

        public int idMoyenPaiement { get; set; }

        public virtual MoyenPaiement MoyenPaiement { get; set; }

        public virtual ICollection<HistoriqueCommande> HistoriqueCommandes { get; set; }



    }


    public enum Civilite
    {
        M,
        Mme,
        Mlle
    }
}
