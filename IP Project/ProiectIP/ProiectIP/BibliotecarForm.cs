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
        public BibliotecarForms(Account account)
        {
            InitializeComponent();
            _account = account;
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

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void buttonAdaugaCarte_click(object sender, EventArgs e)
        {

        }
    }
}
