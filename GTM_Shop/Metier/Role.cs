using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{


    public class Role
    {


        [Key]
        public int idRole { get; set; }

        [Required(ErrorMessage="Un role est obligatoire")]
        [Display(Name = "Type du Role")]
        public string TypeRole { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }

    }
}
