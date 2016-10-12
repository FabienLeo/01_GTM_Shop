using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GTM_Shop.Models
{
    public class ProduitModel
    {

        public int idProduit { get; set; }


        [Required(ErrorMessage = "Un nom de produit est obligatoire")]
        [Display(Name = "Nom")]
        public string NomProduit { get; set; }


        [Required(ErrorMessage = "Un référence fournisseur est obligatoire")]
        [Display(Name = "Réf. fournisseur")]
        public string Reference { get; set; }

        [Column("Prix", TypeName = "Money"), Required(ErrorMessage = "Un prix est obligatoire")]
        public decimal Prix { get; set; }

        [Display(Name = "% Promotion")]
        public double PromotionProduit { get; set; }

        [Required(ErrorMessage = "Une quantité est obligatoire")]
        [Range(typeof(int), "0", "100000", ErrorMessage = "Une quantite ne pas être négative, elle doit être comprise entre 0 et 100 000")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Une déscription est obligatoire")]
        public string Description { get; set; }

        [Display(Name = "Note Client")]
        public double MoyenneNote { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Une image de produit est obligatoire")]
        public string Visuel { get; set; }

        [Display(Name = "Catalogue")]
        public string NomCatalogue { get; set; }

        
    }
}
