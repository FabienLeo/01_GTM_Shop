using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GTM_Shop.Metier
{

    public class Adresse
    {

        [Key, Column(Order = 0)]
        public int idAdresse { get; set; }

        [Required(ErrorMessage="Une ligne d'adresse est obligatoire")]
        [Display(Name = "Numéro et nom de la rue")]
        public string RueLigne01 { get; set; }

        [Display(Name = "Supplément d'adresse")]
        public string RueLigne02 { get; set; }

        [Required(ErrorMessage="Un code postale est obligatoire")]
        [Display(Name = "Code Postale")]
        [DataType(DataType.PostalCode)]
        public string CodePostale { get; set; }

        [Required(ErrorMessage="Une ville est obligatoire")]
        public string Ville { get; set; }

        [Required(ErrorMessage="Un pays est obligatoire")]
        public string Pays { get; set; }

        public virtual ICollection<AdresseClient> AdressesClients { get; set; }


    }
}
