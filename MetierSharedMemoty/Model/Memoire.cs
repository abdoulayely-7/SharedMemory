using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// definir les contraintes des attibus au des  controllers,Vus,et base de donnee => anntations ou decorateurs
using System.ComponentModel.DataAnnotations;
// il ne s applique qu a la base de donnée
using System.ComponentModel.DataAnnotations.Schema;


namespace MetierSharedMemoty.Model
{
    public class Memoire
    {
        [Key]
        public  int IdMemoire  { get; set; }

        [MaxLength(300, ErrorMessage = "Taille maximale 30"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Titre")]
        public string Titre { get; set; }


        [Required (ErrorMessage ="*")]
        public int Annee { get;set; }


        [MaxLength(10, ErrorMessage = "Taille maximale 10")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Statut")]
        public string Status { get;set;}


        [MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Auteur")]
        public string Auteur { get;set;}


        [MaxLength(30, ErrorMessage = "Taille maximale 30"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Nom du Fichier")]
        public string FileName { get;set;}


        [MaxLength(10, ErrorMessage = "Taille maximale 10"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Extension du Fichier")]
        public string Extension { get;set;}



        [DataType(DataType.Date), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        public DateTime? DatePublication { get;set;}

        // un mémoire peut avoir plusieurs jury
            // public virtual ICollection<Jury> Jury { get; set; }


    }
}