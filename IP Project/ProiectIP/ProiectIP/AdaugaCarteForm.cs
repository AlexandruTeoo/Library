using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectIP
{
    public partial class AdaugaCarteForm : Form
    {
        public Account _account;
        public AdaugaCarteForm(Account account)
        {
            InitializeComponent();
            _account = account;
        }
        #region Buttons
        private void buttonAdaugaCartea_click(object sender, EventArgs e) // adauga carte in baza de date
        {
            Book book = new Book();

            book.Title = textBoxTitle.Text;
            book.Author = textBoxAutor.Text;
            book.Category = textBoxCategorie.Text;
            int cartiAdaugate = 0;

            if (int.TryParse(textBoxCartiAdaugate.Text, out cartiAdaugate))
            {
                MessageBox.Show("Cartea urmeaza sa fie inserata");
            }
            else
            {
                MessageBox.Show("Textul introdus nu este un număr întreg valid!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BookDAO.InsertBook(book, cartiAdaugate);
                MessageBox.Show("Carte inserata cu succes!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonInapoi_click(object sender, EventArgs e) // butonul Inapoi intoarce bibliotecarul pe pagina principala al adminului
        {
            BibliotecarForms bibliotecarForms = new BibliotecarForms(_account);
            bibliotecarForms.Show();
            this.Hide();
        }
        #endregion
    }
}
