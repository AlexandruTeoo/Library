using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProiectIP
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                string username = textBox1.Text;
                string parola = textBox2.Text;

                sql = "SELECT * FROM ACCOUNTS WHERE username='" + username + "' AND parola='" + parola + "'";
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
                }
                if(dataReader.GetInt32(10) == 0)
                {
                    UtilizatorForm utilizatorForm = new UtilizatorForm();
                    utilizatorForm.Show();
                    this.Hide();
                }
                else
                {
                    v bibliotecarForm = new v();
                    bibliotecarForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
