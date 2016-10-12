using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public enum TypePaiement
    {
        Facture,
        Cheque,
        Virement,
        CarteBancaire
    }

    public partial class MoyenPaiement
    {

        [Key]
        public int idMoyenPaiement { get; set; }

        [Required]
        public TypePaiement Type { get; set; }

        public virtual ICollection<Client> Clients { get; set; }


    }
}
