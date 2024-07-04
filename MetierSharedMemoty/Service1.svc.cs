using MetierSharedMemoty.Model;
using MetierSharedMemoty.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierSharedMemoty
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        BdSharedMemoryContext db = new BdSharedMemoryContext();
        Logger log = new Logger();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Cette methode permet l'enregistrement d'un membre de jury
        /// </summary>
        /// <param name="jury">Membre jury</param>
        /// <returns> true si ok , sinon false </returns>
        public bool AddJury(Jury jury)
        {
            try
            {
                db.Jurys.Add(jury);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                log.WriteDataError("Service1-AddJury",ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Cette methode permet la modification d'un membre de jury
        /// </summary>
        /// <param name="jury"></param>
        /// <returns>  true si ok , sinon false </returns>
        public bool EditJury(Jury jury)
        {
            try
            {
                var lejury = db.Jurys.Find(jury.IdPersonne);
                if (lejury != null)
                { 
                    lejury.Nom=jury.Nom;
                    lejury.Prenom=jury.Prenom;
                    lejury.Specialite=jury.Specialite;
                    db.SaveChanges();
                    return true;
                }
               
                
            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-EditJury", ex.ToString());
                return false;
            }
            return false;
        }
        /// <summary>
        /// Cette methode permet la suppression d' un membre de jury
        /// </summary>
        /// <param name="juryId"></param>
        /// <returns>  true si ok , sinon false  </returns>
        public bool DeleteJury(int? juryId)
        {
            try
            {
                var lejury = db.Jurys.Find(juryId);
                if (lejury != null)
                {
                   
                    db.Jurys.Remove(lejury);
                    db.SaveChanges();
                    return true;
                }

                
            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-EditJury", ex.ToString());
                return false;
            }
            return false;
        }

        /// <summary>
        /// Cette methode permet la recherche sans argument
        /// </summary>
        /// <returns> returne la liste des jurys </returns>
        public List<Jury>  GetJurys()
        {
            return db.Jurys.ToList();
        }


        /// <summary>
        /// Cette methode permet la recherche avec argument
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Prenom"></param>
        /// <param name="Specialite"></param>
        /// <returns>  la liste </returns>
        public List<Jury>  GetsJurys(string Nom,string Prenom, string Specialite)
        {
            var liste = db.Jurys.ToList();
            if (!string.IsNullOrEmpty(Nom))
            {
                liste = liste.Where(a => a.Nom.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Prenom))
            {
                liste =liste.Where(a => a.Prenom.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Specialite))
            {
                liste =liste.Where(a => a.Specialite.ToUpper().Contains(Specialite.ToUpper())).ToList();
            }
            return liste;
        }
    }
}
