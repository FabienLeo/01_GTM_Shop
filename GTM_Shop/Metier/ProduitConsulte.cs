using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class ProduitConsulte
    {


        [Key, Column(Order = 0)]
        public int idProduit { get; set; }


        [Key, Column(Order = 1)]
        public int idUtilisateur { get; set; }


        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }

        [Display(Name = "Date de la consultation du produit")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateConsultation { get; set; }


    }
}
