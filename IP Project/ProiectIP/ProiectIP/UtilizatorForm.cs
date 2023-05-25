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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProiectIP
{
    public partial class UtilizatorForm : Form
    {
        public Account _account;
        public bool isOnLoan = false;
        public UtilizatorForm(Account account)
        {
            _account = account;
            InitializeComponent();
            label1.Text = label1.Text + _account._username + "!";
        }
        #region Buttons
        private void AddtoWishlist_Click(object sender, EventArgs e)
        {
            if (isOnLoan)
                return;

            if (listBoxUtilizatorForm.SelectedItem != null)
            {
                Book selectedBook = (Book)listBoxUtilizatorForm.SelectedItem;
                Wishlist wishlist = new Wishlist();
                wishlist._accountId = _account._id;
                wishlist._isbn = selectedBook._isbn;

                List<Book> wishlistedBooks = WishlistDAO.GetWishlist(_account._id);
                bool ok = false;
                foreach(Book book in wishlistedBooks)
                {
                    if (book._isbn == selectedBook._isbn)
                        ok = true;
                }

                 // Verificați dacă elementul selectat este deja în wishlist
                if (ok==true)
                {
                    MessageBox.Show("Cartea este deja în Wishlist!");
                }
                else
                {
                    WishlistDAO.AddBookWishlist(wishlist);
                    MessageBox.Show("Carte adăugata în Wishlist!");
                }
            }
            else
            {
                MessageBox.Show("Selectați o carte din lista pentru a o adăuga în Wishlist!");
            }
        }

        private void buttonImprumuta_Click(object sender, EventArgs e)// de editat pt forms
        {
            if (isOnLoan)
                return;

            Loan loan = new Loan();
            Book selectedBook = (Book)listBoxUtilizatorForm.SelectedItem;
            loan._accountId = _account._id;
            loan._isbn = selectedBook._isbn;

            try
            {
                LoanDAO.AddLoan(loan);
                MessageBox.Show("Cerere de imprumut trimisa cu succes", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OracleException ex)
            {
                //SqlException ex = (SqlException)procedureError.InnerException;
                if (ex.Number == 20003)
                {
                    MessageBox.Show("Stoc insuficient!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
        }

        private void buttonShowWishlist_click(object sender, EventArgs e)// de editat pt forms
        {
            isOnLoan = false;

            List<Book> wishlist = WishlistDAO.GetWishlist(_account._id);
            if (wishlist.Count > 0)
            {
                listBoxUtilizatorForm.Items.Clear();
                foreach (Book book in wishlist)
                {
                    listBoxUtilizatorForm.Items.Add(book);
                }
            }
            else
            {
                MessageBox.Show("Wishlist-ul este gol!");
            }
        }

        private void buttonShowBooks_click(object sender, EventArgs e)// de editat pt forms
        {
            isOnLoan=false;

            listBoxUtilizatorForm.Items.Clear();
            List<Book> books = BookDAO.GetBooks();
            foreach(Book book in books)
            {
                listBoxUtilizatorForm.Items.Add(book);
            }
        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void removeWishlist_Click(object sender, EventArgs e)
        {
            if (isOnLoan)
                return;

            if (listBoxUtilizatorForm.SelectedItem != null)
            {
                Book selectedBook = (Book)listBoxUtilizatorForm.SelectedItem;
                Wishlist wishlist = new Wishlist();
                wishlist._accountId = _account._id;
                wishlist._isbn = selectedBook._isbn;
                WishlistDAO.DeleteBookWishlist(wishlist);
                //wishlist.Remove(selectedBook);
                MessageBox.Show("Carte eliminată din Wishlist!");

                // Actualizare afișare Wishlist
                RefreshWishlist();
            }
            else
            {
                MessageBox.Show("Selectați o carte din Wishlist pentru a o elimina!");
            }
        }


        private void showLoans_Click(object sender, EventArgs e)
        {
            isOnLoan = true;

            listBoxUtilizatorForm.Items.Clear();
            List<Loan> loans = LoanDAO.GetLoans(_account._id);
            foreach (Loan loan in loans)
            {
                listBoxUtilizatorForm.Items.Add(loan);
            }
        }
        #endregion
        #region RefreshList
        private void RefreshWishlist()
        {
            isOnLoan = false;

            // Ștergeți conținutul din ListBox-ul de Wishlist
            listBoxUtilizatorForm.Items.Clear();
            List<Book> wishlist = WishlistDAO.GetWishlist(_account._id);
            // Adăugați cărțile din wishlist în ListBox-ul de Wishlist
            foreach (Book book in wishlist)
            {
                listBoxUtilizatorForm.Items.Add(book);
            }
        }
        #endregion
    }
}
