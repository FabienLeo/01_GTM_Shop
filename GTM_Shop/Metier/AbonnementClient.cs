using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class AbonnementClient
    {

        [Key, Column(Order = 0)]
        public int idAbonnement{ get; set; }

        [Key, Column(Order = 1)]
        public int idUtilisateur { get; set; }

        public virtual Client Client { get; set; }

        public virtual Abonnement Abonnement { get; set; }

    }
}
