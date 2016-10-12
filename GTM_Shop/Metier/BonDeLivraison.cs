using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{


    public class BonDeLivraison
    {

        [Key]
        public int idBonDeLivraison { get; set; }


        [Required(ErrorMessage="Un nom de distributeur est obligatoire")]
        [Display(Name = "Nom du distributeur")]
        public string NomDistributeur { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
