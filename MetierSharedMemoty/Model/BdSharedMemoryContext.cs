using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace MetierSharedMemoty.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSharedMemoryContext:DbContext
    {
        public BdSharedMemoryContext():base("connSharedmemory") { }
        
        // appeler la classe Personne pour qu il soit ds la base de donnée
        public  DbSet<Personne> Personnes { get; set; }
        public  DbSet<Memoire> Memoires { get; set; }
        public DbSet<Jury> Jurys { get; set; }

        public DbSet<Td_Erreur> Td_Erreurs { get; set; }

        public DbSet<Jurymemoire> JuryMemoires { get; set; }
    }
}