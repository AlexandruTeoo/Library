using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TERMINAT

namespace ProiectIP
{
    public class AccountDAO
    {
        #region GetAccount
        public static Account GetAccount(string username, string password)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "SELECT * FROM ACCOUNTS WHERE username='" + username + "' AND parola='" + password + "'";
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
                    return account;
                }
                return null;
            }
        }
        #endregion
        #region InsertAccount
        public static void InsertAccount(Account account)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "BEGIN \n insert_account('" + account._username + "', '" + account._password + "', '" + account._nume + "'," +
                    " ' " + account._prenume + "', '" + account._cnp + "', ' " + account._email + "'," +
                " ' " + account._address + "', '" + account._city + "', '" + account._phoneNumber + "', 0, 0); \n END;";

                OracleCommand command = new OracleCommand(sql, connection);
                command.Connection.Open();

                command.ExecuteReader(); 
            }
        }
        #endregion
    }
}
