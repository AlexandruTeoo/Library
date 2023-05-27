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
using AccountLibrary;
using BookLibrary;

namespace ProiectIP
{
    public partial class ModificaCarte : Form
    {
        public Book _selectedBook;
        public Account _account;
        public ModificaCarte(Account account, Book book)
        {
            _account = account;
            _selectedBook = book;
            InitializeComponent();
            label1.Text = label1.Text + "'" +_selectedBook.Title + "'";
            textBoxTitle.Text = _selectedBook.Title;
            textBoxAutor.Text = _selectedBook.Author;
            textBoxCategorie.Text = _selectedBook.Category;    
        }
        #region Buttons
        private void Inapoi_Click(object sender, EventArgs e) // la apasarea butonului Inapoi se va reveni pe pagina de administrare a bibliotecarului
        {
            BibliotecarForms bibliotecarForms = new BibliotecarForms(_account);
            bibliotecarForms.Show();
            this.Hide();
        }

        private void buttonModifica_Click(object sender, EventArgs e) // la apasarea butonului Modifica, detaliile cartii se vor modifica in functie de datele introduse
        {
            _selectedBook.Title = textBoxTitle.Text;
            _selectedBook.Author = textBoxAutor.Text;
            _selectedBook.Category = textBoxCategorie.Text;

            try
            {
                BookDAO.ModifyBook(_selectedBook);
                MessageBox.Show("Carte modificata cu succes!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); // modificare reusita
            }
            catch (OracleException ex)
            {  
                MessageBox.Show(ex.Message, "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); // date introduse gresit
            }
        }
        #endregion
    }
}
