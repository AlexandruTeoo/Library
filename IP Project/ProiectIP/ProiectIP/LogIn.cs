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
    }
}
