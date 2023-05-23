using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProiectIP
{
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void backLogIn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void buttonInregistrare_Click(object sender, EventArgs e)
        { 
            Account account = new Account();

            account._username = textBoxUsername.Text;
            account._password = textBoxParola.Text;
            account._nume = textBoxNume.Text;
            account._prenume = textBoxPrenume.Text;
            account._cnp = textBoxCNP.Text;
            account._email = textBoxEmail.Text;
            account._address = textBoxAdresa.Text;
            account._city = textBoxOras.Text;
            account._phoneNumber = textBoxTelefon.Text;

            if(account._cnp.Length != 13)
            {
                MessageBox.Show("CNP invalid", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (account._phoneNumber.Length != 10)
            {
                MessageBox.Show("Numar de telefon invalid", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AccountDAO.InsertAccount(account);
                MessageBox.Show("Utilizator inserat cu succes!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogIn logare = new LogIn();
                logare.Show();
                this.Hide();
            }
            catch(OracleException ex) 
            {
                //SqlException ex = (SqlException)procedureError.InnerException;
                if (ex.Number == 20001)
                {
                    MessageBox.Show("Email deja existent!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                    if (ex.Number == 20002)
                    {
                        MessageBox.Show("Username deja existent!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
