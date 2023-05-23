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
        public BibliotecarForms()
        {
            InitializeComponent();
        }

        private void buttonShowBooks_click(object sender, EventArgs e) // de editat pt forms
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql, Output = "";
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

        private void buttonDeleteBook_click(object sender, EventArgs e)// de editat pt forms
        {

        }

        private void buttonModifyDetailsBook_Click(object sender, EventArgs e)// de editat pt forms
        {

        }

        private void buttonShowAllAccounts_click(object sender, EventArgs e)// de editat pt forms
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "SELECT * FROM ACCOUNTS";
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    Account account = new Account(dataReader.GetInt32(0),
                        dataReader.GetString(1),
                        dataReader.GetString(2),
                        dataReader.GetString(3),
                        dataReader.GetString(4),
                        dataReader.GetString(5),
                        dataReader.GetString(6),
                        dataReader.GetString(7),
                        dataReader.GetString(8),
                        dataReader.GetString(9),
                        dataReader.GetInt32(10),
                        dataReader.GetInt32(11)
                        );
                   // return account;
                }
                //return null;
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
