/**************************************************************************
 *                                                                        *
 *  File:        ProiectIP                                                *
 *  Copyright:   (c) 2023, Alexandru-Teodor Atanase                       *
 *  E-mail:      alexandru-teodor.atanase@student.tuiasi.ro               *
 *  Website:     https://github.com/AlexandruTeoo/IP-Projec               *
 *  Description: BibliotecarForm.cs (class)                                 *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

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
using AccountLibrary;
using BookLibrary;
using LoanLibrary;

namespace ProiectIP
{
    public partial class BibliotecarForms : Form
    {
        public Account _account;
        public bool isOnLoan = false;
        public BibliotecarForms(Account account)
        {
            _account = account;
            InitializeComponent();
            label1.Text = label1.Text + _account.Prenume + "!"; 
        }
        #region Buttons
        private void buttonShowBooks_click(object sender, EventArgs e) // afiseaza cartile
        {
            isOnLoan = false;

            List<Book> books = BookDAO.GetBooks();

            listBoxBibliotecarForm.Items.Clear();
            foreach (Book book in books)
            {
                listBoxBibliotecarForm.Items.Add(book);
            }
        }

        private void buttonDeleteBook_click(object sender, EventArgs e) // sterge o carte din biblioteca
        {
            if (isOnLoan)
                return;

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
                MessageBox.Show("Selectați o carte din lista pentru a o elimina!");
            }
        }

        private void buttonModifyDetailsBook_Click(object sender, EventArgs e) // modifica o carte din biblioteca
        {
            if (isOnLoan)
                return;
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

        private void buttonDeconectare_Click(object sender, EventArgs e) // deconecteaza bibliotecarul de la cont
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void buttonAdaugaCarte_click(object sender, EventArgs e) // bibliotecarul poate adauga o carte in biblioteca
        {
            AdaugaCarteForm adaugaCarte = new AdaugaCarteForm(_account);
            adaugaCarte.Show();
            this.Hide();
        }

        private void Imprumuturi_Click(object sender, EventArgs e) // vizualizare imprumuturi
        {
            isOnLoan = true;

            List<Loan> loans = LoanDAO.GetAllLoans();

            listBoxBibliotecarForm.Items.Clear();
            foreach (Loan loan in loans)
            {
                listBoxBibliotecarForm.Items.Add(loan);
            }
        }

        private void buttonAcceptaImprumut_Click(object sender, EventArgs e) // bibliotecarul accepta cererile de imprumut facute de catre utilizatori 
        {
            if (!isOnLoan)
                return;

            if (listBoxBibliotecarForm.SelectedItem != null)
            {
                Loan selectedLoan = (Loan)listBoxBibliotecarForm.SelectedItem;
                try
                {
                    LoanDAO.ApproveLoan(selectedLoan.LoanId);
                    MessageBox.Show("Cerere aprobata cu succes!");
                    RefreshLoans();
                }
                catch(OracleException ex)
                {
                    if(ex.Number == 20050)
                    {
                        MessageBox.Show("Stoc insuficient!", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning); // nu sunt suficiente carti in biblioteca
                    }
                    MessageBox.Show(ex.Message, "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Selectați o cerere din lista pentru a o accepta!");
            }
        }
        #endregion
        #region RefreshList
        private void RefreshLoans()
        {
            isOnLoan = true;
            // Ștergeți conținutul din ListBox-ul de Wishlist
            listBoxBibliotecarForm.Items.Clear();
            List<Loan> loans = LoanDAO.GetAllLoans();
            // Adăugați cărțile din wishlist în ListBox-ul de Wishlist
            foreach (Loan loan in loans)
            {
                listBoxBibliotecarForm.Items.Add(loan);
            }
        }
        private void RefreshBooks()
        {
            isOnLoan = false;
            // Ștergeți conținutul din ListBox-ul de Wishlist
            listBoxBibliotecarForm.Items.Clear();
            List<Book> books = BookDAO.GetBooks();
            // Adăugați cărțile din wishlist în ListBox-ul de Wishlist
            foreach (Book book in books)
            {
                listBoxBibliotecarForm.Items.Add(book);
            }
        }
        #endregion
    }
}
