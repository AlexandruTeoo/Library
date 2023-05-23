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

namespace ProiectIP
{
    public partial class UtilizatorForm : Form
    {
        public UtilizatorForm()
        {
            InitializeComponent();
        }

        private void AddtoWishlist_Click(object sender, EventArgs e)// de editat pt forms
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                string bookInfo = listBoxUtilizatorForm.Text;
                
                int accountId = 1; // de vazut cum se poate accesa id-ul contului odata logat
                string isbn = "1"; // parsat bookInfo pentru a optine isbn

                sql = "CREATE OR REPLACE PROCEDURE insert_wishlist(" +
                                               accountId + "," +
                                               isbn + ")";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    // ?
                }
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
        }

        private void buttonShowBooks_click(object sender, EventArgs e)// de editat pt forms
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "Select * from CARTI";
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                List<Book> books = new List<Book>();

                while (dataReader.Read())
                {
                    Book book = new Book(dataReader.GetInt32(0),
                                        dataReader.GetString(1),
                                        dataReader.GetString(2),
                                        dataReader.GetString(3),
                                        dataReader.GetInt32(4),
                                        dataReader.GetInt32(5));

                    books.Add(book);
                }
                Console.WriteLine(books);
                //return books;
            }
        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }
    }
}
