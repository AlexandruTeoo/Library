using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProiectIP
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        #region Buttons
        private void buttonConectare_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string parola = textBox2.Text;

            Account account = AccountDAO.GetAccount(username,parola);

            if(account == null)
            {
                MessageBox.Show("Utilizator incorect!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (account._accountType == 0)
            {
                UtilizatorForm utilizatorForm = new UtilizatorForm(account);
                utilizatorForm.Show();
                this.Hide();
            }
            if (account._accountType == 1)
            {
                BibliotecarForms bibliotecarForm = new BibliotecarForms(account);
                bibliotecarForm.Show();
                this.Hide();
            }
        }

        private void Inregistrare_Click(object sender, EventArgs e)
        {
            Inregistrare inregistare = new Inregistrare();
            inregistare.Show();
            this.Hide();
        }

        private void buttonDespre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                   Proiect realizat de Radu Dumitriu și Atanase Alexandru \n\n" +
                "                                   Tema proiectului:Evidența Biblioteca \n\n" +
                "Descriere:     Proiectul constă în dezvoltarea unei interfețe grafice pentru administrarea cărţilor dintr-o bibliotecă, " +
                "cu posibilitatea de a împrumuta. Împrumutul se face pe baza informațiilor cărții (ISBN, titlu, gen, autor, editura) " +
                "și pe baza datelor personale ale abonatului (nume, prenume, CNP, adresă). Utilizatorii acestei aplicații sunt grupați " +
                "în administratori (bibliotecari) şi utilizatori (abonați). Accesul utilizatorului la informații este restricționat. " +
                "El poate să consulte disponibilitatea cărților, să introducă noi cărți în \"wishlist\", să aplice pentru a împrumuta cărți. " +
                "Administratorul poate să realizeze orice operație asupra bazei de date. El introduce cărți în lista bibliotecii, şterge cărți, " +
                "schimbă statutul unei cărți (disponibilă doar pentru sala de lectură/împrumut acasă), aprobă împrumuturile solicitate de către abonați. " +
                "Administratorul revizuieşte lista abonaților în vederea limitării împrumuturilor acestora în cazul în care apar întârzieri la restituirea cărților.");
        }
        #endregion
    }
}
