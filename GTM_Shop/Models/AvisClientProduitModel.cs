using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GTM_Shop.Models
{
    public class AvisClientProduitModel
    {

        public int idProduit { get; set; }


        
        [Display(Name = "Nom")]
        public string NomProduit { get; set; }


       
        [Display(Name = "Réf. fournisseur")]
        public string Reference { get; set; }

       
        public decimal Prix { get; set; }

        
        
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        
        public string Description { get; set; }

        [Display(Name = "Note Client")]
        public double MoyenneNote { get; set; }

        public string Visuel { get; set; }

        [Display(Name = "% Promotion")]
        public double PromotionProduit { get; set; }


        public int idUtilisateur { get; set; }
    
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }



        [Display(Name = "Note")]
        public double NoteAvis { get; set; }

        [Display(Name = "Commentaire")]
        public string TextAvis { get; set; }
    }
}