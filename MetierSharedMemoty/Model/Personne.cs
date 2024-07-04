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
    public class Personne
    {
        [Key]
        public int IdPersonne { get; set; }

        [MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        // Le texte qui doit etre sur le label
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

    }
}