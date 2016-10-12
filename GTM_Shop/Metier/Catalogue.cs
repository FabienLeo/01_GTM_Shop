using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Catalogue
    {

        [Key]
        public int idCatalogue { get; set; }

        [Required(ErrorMessage="Un nom de catalogue est obligatoire")]
        [Display(Name = "Nom du catalogue")]
        public string NomCatalogue { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
