using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProiectIP
{
    public partial class BibliotecarForms : Form
    {
        public Account _account;
        public bool onLoan = false;
        public BibliotecarForms(Account account)
        {
            _account = account;
            InitializeComponent();
            label1.Text = label1.Text + _account._prenume + "!"; 
        }

        private void buttonShowBooks_click(object sender, EventArgs e) // de editat pt forms
        {
            List<Book> books = BookDAO.GetBooks();

            listBoxBibliotecarForm.Items.Clear();
            foreach (Book book in books)
            {
                listBoxBibliotecarForm.Items.Add(book);
            }
        }

        private void buttonDeleteBook_click(object sender, EventArgs e)// de editat pt forms
        {
            if (listBoxBibliotecarForm.SelectedItem != null)
            {
                Book selectedBook = (Book)listBoxBibliotecarForm.SelectedItem;
                BookDAO.DeleteBook(selectedBook);
                //wishlist.Remove(selectedBook);
                MessageBox.Show("Carte eliminată!");

                // Actualizare afișare Wishlist
                RefreshBooks();
            }
            else
            {
                MessageBox.Show("Selectați o carte din Wishlist pentru a o elimina!");
            }
        }

        private void RefreshBooks()
        {
            // Ștergeți conținutul din ListBox-ul de Wishlist
            listBoxBibliotecarForm.Items.Clear();
            List<Book> books = BookDAO.GetBooks();
            // Adăugați cărțile din wishlist în ListBox-ul de Wishlist
            foreach (Book book in books)
            {
                listBoxBibliotecarForm.Items.Add(book);
            }
        }

        private void buttonModifyDetailsBook_Click(object sender, EventArgs e)// de editat pt forms
        {
            if (listBoxBibliotecarForm.SelectedItem != null)
            {
                Book selectedBook = (Book)listBoxBibliotecarForm.SelectedItem;
                ModificaCarte modifCarte = new ModificaCarte(_account, selectedBook);
                modifCarte.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selectați o carte din lista pentru a o modifica!");
            }
        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void buttonAdaugaCarte_click(object sender, EventArgs e)
        {
            AdaugaCarteForm adaugaCarte = new AdaugaCarteForm(_account);
            adaugaCarte.Show();
            this.Hide();
        }

        private void Imprumuturi_Click(object sender, EventArgs e)
        {
            List<Loan> loans = LoanDAO.GetAllLoans();

            listBoxBibliotecarForm.Items.Clear();
            foreach (Loan loan in loans)
            {
                listBoxBibliotecarForm.Items.Add(loan);
            }
        }
    }
}
