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
    public class Jurymemoire
    {
        [Key]
        [Column (Order =1)]
        public int? IdMemoire { get; set; }
        [ForeignKey("IdMemoire")]

        public virtual Memoire memoire { get; set; } 
        [Key]
        [Column (Order =2)]
        public int? IdJury { get; set; }
        [ForeignKey("IdJury")]

        public virtual Memoire jury { get; set; }

    }
}