using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Panier
    {

        [Key]
        public int idPanier { get; set; }


        [Required]
        public bool EstVide { get; set; }

        public virtual ICollection<LigneCommande> LignesCommandes { get; set; }
    }
}
