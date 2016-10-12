using GTM_Shop.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTM_Shop.Models
{
    public class ProfilModel
    {
        public int idAdresse { get; set; }

        public int idUtilisateur { get; set; }

        public string Avatar { get; set; }


        [Display(Name = "Civilité")]
        public Civilite CiviliteClient { get; set; }

        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Display(Name = "Date de naissance")]
        public DateTime DateDeNaissance { get; set; }

        [Display(Name = "Numéro et nom de la rue")]
        public string RueLigne01 { get; set; }

        [Display(Name = "Supplément d'adresse")]
        public string RueLigne02 { get; set; }

        [Display(Name = "Code Postale")]
        public string CodePostale { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }

        [Display(Name = "Point Fidélité")]
        public int PointFidelite { get; set; }

    }
}