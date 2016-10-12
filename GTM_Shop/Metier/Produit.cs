using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Produit
    {


        [Key]
        public int idProduit { get; set; }


        [Required(ErrorMessage="Un nom de produit est obligatoire")]
        [Display(Name = "Nom")]
        public string NomProduit { get; set; }


        [Required(ErrorMessage="Un référence fournisseur est obligatoire")]
        [Display(Name = "Réf. fournisseur")]
        public string Reference { get; set; }

        [Column("Prix", TypeName = "Money"), Required(ErrorMessage="Un prix est obligatoire")]
        public decimal Prix { get; set; }

        [Required(ErrorMessage="Une quantité est obligatoire")]
        [Range(typeof(int), "0", "100000", ErrorMessage = "Une quantite ne pas être négative, elle doit être comprise entre 0 et 100 000")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage="Une déscription est obligatoire")]
        public string Description { get; set; }

        [Display(Name = "Note Client")]
        public double MoyenneNote { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage="Une image de produit est obligatoire")]
        public string Visuel { get; set; }

        [Display(Name = "% Promotion")]
        public double PromotionProduit { get; set; }

        public int idCatalogue{ get; set; }

        public virtual Catalogue Catalogue { get; set; }


        public virtual ICollection<Avis> Avis { get; set; }

        public virtual ICollection<ProduitConsulte> ProduitsConsultes { get; set; }

        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }

    }
}
