using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Utilisateur
    {


        [Key]
        public int idUtilisateur{ get; set; }


        [Required]
        [Display(Name = "Sexe")]
        public Sexe SexeUtilisateur { get; set; }



        [Required(ErrorMessage="Un nom de famille est obligatoire")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }


        [Required(ErrorMessage="Un prénom est obligatoire")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }


        [Index(IsUnique = true), Required(ErrorMessage="Un email est obligatoire et unique"), Column("Email", TypeName = "varchar")]
        [Display(Name = "Adresse Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "L'adresse Email n'est pas valide")] 
        public string Email { get; set; }


        [Required(ErrorMessage = "Un mot de passe est obligatoire"), MinLength(6, ErrorMessage = "le mot de passe doit contenir au minimum 6 caractères ")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Une confirmation de mot de passe est obligatoire")]
        [Display(Name = "Confirmation de votre Mot de Passe")]
        [Compare("MotDePasse", ErrorMessage = "Confirmation de Mot de Passe non identique")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmationMotDePasse { get; set; }

        // Chemin de la source de l'image d'avatar du compte
        [DataType(DataType.ImageUrl)]
        public string Avatar { get; set; }

        [Display(Name = "Type du Role")]
        public int idRole { get; set; }
        public virtual Role RoleUtilisateur { get; set; }


    }


    public enum Sexe
    {

        Homme,
        Femme,
    }



}
