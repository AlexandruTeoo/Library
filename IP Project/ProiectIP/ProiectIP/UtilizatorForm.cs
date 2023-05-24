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
        List<Book> wishlist = new List<Book>();
        public Account _account;
        public UtilizatorForm(Account account)
        {
            _account = account;
            InitializeComponent();
            label1.Text = label1.Text + _account._username + "!";
        }
        /*
        private void AddtoWishlist_Click(object sender, EventArgs e)// de editat pt forms
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                string bookInfo = listBoxUtilizatorForm.Text;
                
                int accountId = 1; // de vazut cum se poate accesa id-ul contului odata logat
                string isbn = "1"; // parsat bookInfo pentru a optine isbn

                sql = "BEGIN \n insert_wishlist(" + accountId + "," + isbn + "); \n END;" ;

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    // ?
                }

                if (listBoxUtilizatorForm.SelectedItem != null)
                {
                    // Obțineți valoarea (titlul cărții) din elementul selectat
                    string selectedBook = listBoxUtilizatorForm.SelectedItem.ToString();

                    // Adăugați valoarea într-o listă de dorințe (Wishlist)
                    // wishlist.Add(selectedBook);
                }

            }
        }
        */
        
        private void AddtoWishlist_Click(object sender, EventArgs e)
        {

            if (listBoxUtilizatorForm.SelectedItem != null)
            {
                Book selectedBook = (Book)listBoxUtilizatorForm.SelectedItem;

                // Verificați dacă elementul selectat este deja în wishlist
                if (wishlist.Contains(selectedBook))
                {
                    MessageBox.Show("Cartea este deja în Wishlist!");
                }
                else
                {
                    wishlist.Add(selectedBook);
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
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                string bookInfo = listBoxUtilizatorForm.Text;
                int accountId = 1;
                string isbn = "1";// parsat bookInfo pentru a optine isbn
                DateTime issuedDate = DateTime.Now.Date;
                DateTime returnedDate = DateTime.Now.Date.AddDays(14);
                sql = "CREATE OR REPLACE PROCEDURE insert_loan(" +
                                                accountId + "," +
                                                isbn + "," +
                                                issuedDate + "," +
                                                returnedDate + ")";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.GetInt32(1) == null)
                    {
                        //return -2; // acc not found -> trebuie verificat cu loan._accountId in sql??
                    }
                    //return 0;
                }
                //return -1;
            }
        }

        private void buttonShowWishlist_click(object sender, EventArgs e)// de editat pt forms
        {
            /*
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                int accountId = 1;

                sql = "Select * from WISHLIST WHERE account_id = '" + accountId + "'";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    List<Wishlist> wishlist = new List<Wishlist>();

                    while (dataReader.Read())
                    {
                        Wishlist loan = new Wishlist(
                            dataReader.GetString(0),
                            dataReader.GetInt32(1)
                        );

                        wishlist.Add(loan);
                    }
                    //return wishlist;
                }
                //return null;
            }
            */

            // Ștergeți conținutul din ListBox
            

            // Afișați conținutul din wishlist într-un MessageBox
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
            if (listBoxUtilizatorForm.SelectedItem != null)
            {
                Book selectedBook = (Book)listBoxUtilizatorForm.SelectedItem;

                wishlist.Remove(selectedBook);
                MessageBox.Show("Carte eliminată din Wishlist!");

                // Actualizare afișare Wishlist
                RefreshWishlist();
            }
            else
            {
                MessageBox.Show("Selectați o carte din Wishlist pentru a o elimina!");
            }
        }

        private void RefreshWishlist()
        {
            // Ștergeți conținutul din ListBox-ul de Wishlist
            listBoxUtilizatorForm.Items.Clear();

            // Adăugați cărțile din wishlist în ListBox-ul de Wishlist
            foreach (Book book in wishlist)
            {
                listBoxUtilizatorForm.Items.Add(book);
            }
        }
    }
}
