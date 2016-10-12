using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{


    public class LigneCommande
    {


        [Key]
        public int idLigneCommande { get; set; }


        [Required(ErrorMessage="Une quantité est obligatoire")]
        [Range(typeof(int), "0", "100000", ErrorMessage = "Une quantite ne pas être négative, elle doit être comprise entre 0 et 100 000")]
        public int Quantite { get; set; }

        public double PromotionLigneCommande { get; set; }

        public int idProduit { get; set; }

        public virtual Produit Produit { get; set; }


        public int idCommande { get; set; }

        public virtual Commande Commande { get; set; }

        public int idPanier { get; set; }

        public virtual Panier Panier { get; set; }

    }
}
