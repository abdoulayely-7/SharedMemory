using AppSharedMemory.ServiceMetier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace AppSharedMemory
{
    public partial class Form1 : Form
    {
        ServiceMetier.Service1Client service = new ServiceMetier.Service1Client();

        public Form1()
        {
            service = new ServiceMetier.Service1Client();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgJury.DataSource = service.GetJurys();
        }

        /// <summary>
        /// Cette methode permet d'ajouter un jury via le bouton ajouter du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAjouter_Click(object sender, EventArgs e)
        {
            ServiceMetier.Jury jury = new ServiceMetier.Jury();
            jury.Nom = txtNom.Text;
            jury.Prenom = txtPrenom.Text;
            jury.Grade = txtGrade.Text;
            jury.Specialite = txtSpecialite.Text;
            service.AddJury(jury);
            Effacer();
        }

        /// <summary>
        /// cette methode permet de vider les champs des textBox
        /// </summary>
        public void Effacer()
        {
            txtNom.Text = String.Empty;
            txtPrenom.Text = string.Empty;
            txtGrade.Text = String.Empty;
            txtSpecialite.Text = String.Empty;
            dgJury.DataSource = service.GetJurys();
            txtNom.Focus();
        }

        /// <summary>
        /// cette methode permet de selectionner les donnees du tableau et les mettent respectivement  dans les textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtNom.Text = dgJury.CurrentRow.Cells[3].Value.ToString();
            txtPrenom.Text = dgJury.CurrentRow.Cells[4].Value.ToString();
            txtGrade.Text = dgJury.CurrentRow.Cells[0].Value.ToString();
            txtSpecialite.Text = dgJury.CurrentRow.Cells[1].Value.ToString();
        }

        /// <summary>
        /// Cette methode permet de modifier un jury via le bouton modifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgJury.CurrentRow != null)
            {
                ServiceMetier.Jury jury = new ServiceMetier.Jury
                {
                    IdPersonne = int.Parse(dgJury.CurrentRow.Cells[2].Value.ToString()), 
                    Nom = txtNom.Text,
                    Prenom = txtPrenom.Text,
                    Grade = txtGrade.Text,
                    Specialite = txtSpecialite.Text
                };
                service.EditJury(jury);
                Effacer();
            }
        }

        /// <summary>
        /// cette methode permet de supprimer un jury via le bouton supprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {

            if (dgJury.CurrentRow != null)
            {
                int juryId = int.Parse(dgJury.CurrentRow.Cells[2].Value.ToString()); 
                service.DeleteJury(juryId);
                Effacer();
            }
        }
    
    }
}
