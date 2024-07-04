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
    public class Jury:Personne
    {
        [MaxLength(20, ErrorMessage = "Taille maximale 20"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Grade membre du jury")]
        public string Grade { get; set; }

        [MaxLength(20, ErrorMessage = "Taille maximale 20"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Spécialité membre du jury")]
        public string Specialite { get; set; }


        // un membre de jury  peut être dans  plusieurs mémoire
            //  public virtual ICollection<Memoire> Memoires { get; set; }
    }
}