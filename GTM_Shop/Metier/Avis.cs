using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Avis
    {
         
        [Key, Column(Order = 0)]
        public int idProduit { get; set; }


        [Key, Column(Order = 1)]
        public int idUtilisateur { get; set; }

        [Range(typeof(double), "0", "5", ErrorMessage = "Votre note doit être comprise entre 0 et 5")]
        [Display(Name = "Note")]
        public double NoteAvis { get; set; }

        [Display(Name = "Commentaire")]
        public string TextAvis { get; set; }

        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }


    }
}
