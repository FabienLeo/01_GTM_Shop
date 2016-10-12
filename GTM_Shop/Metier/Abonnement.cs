using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GTM_Shop.Metier
{

    public class Abonnement
    {


        [Key]
        public int idAbonnement { get; set; }
 

        [Required(ErrorMessage="Un nom d'abonnement est obligatoire")]
        [Display(Name = "Nom de l'abonnement")]
        public string NomAbonnement { get; set; }

        [Required(ErrorMessage = "Une date de début est obligatoire")]
        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "Une date de fin est obligatoire")]
        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFin { get; set; }

        [Column("PrixAbonnement", TypeName = "Money"), Required(ErrorMessage="Un prix d'abonnement est obligatoire")]
        [Display(Name = "Prix de l'abonnement")]
        public decimal PrixAbonnement { get; set; }

        public virtual ICollection<AbonnementClient> AbonnementsClients { get; set; }


    }
}
