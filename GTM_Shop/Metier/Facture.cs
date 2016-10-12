using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Facture
    {

        [Key]
        public int idFacture { get; set; }

        [Required(ErrorMessage="Une TVA est obligatoire")]
        public decimal TVA { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }

    }
}
