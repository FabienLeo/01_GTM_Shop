using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Commande
    {

        [Key]
        public int idCommande { get; set; }

        public string Commentaire { get; set; }

        public virtual ICollection<LigneCommande> LignesCommandes { get; set; }

        [Display(Name ="Référence Facture")]
        public int idFacture { get; set; }

        public virtual Facture Facture { get; set; }

        [Display(Name = "Référence BdL")]
        public int idBonDeLivraison { get; set; }

        public virtual BonDeLivraison BonDeLivraison { get; set; }

        public int idStatut { get; set; }

        public virtual Statut Statut { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

    }
}
