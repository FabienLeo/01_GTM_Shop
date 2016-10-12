using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{
    

    public enum StatutCommande
    {

        EnAttente,
        EnCours,
        Termine,
        Abandonne
    }


    public partial class Statut
    {

        [Key]
        public int idStatut { get; set; }

        [Required]
        public StatutCommande Valeur { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }


    }
}
