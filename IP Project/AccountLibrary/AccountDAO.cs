/**************************************************************************
 *                                                                        *
 *  File:        AccountLibrary.dll                                               *
 *  Copyright:   (c) 2023, Florin Leon                               *
 *  E-mail:      florin.leon@academic.tuiasi.ro                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.html             *
 *  Description: AccountDAO ()    *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;


namespace AccountLibrary
{
    public class AccountDAO
    {
        #region GetAccount
        public static Account GetAccount(string username, string password)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString())) // conexiune baza de date
            {
                String sql;

                sql = "SELECT * FROM ACCOUNTS WHERE username='" + username + "' AND parola='" + password + "'"; // selecteaza toate conturile care au username-ul si
                                                                                                                // parola egale cu parametrii (username, password)
                // Creăm un obiect OracleCommand pentru a executa instrucțiunea SQL
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open(); // Deschidem conexiunea către baza de date utilizând obiectul OracleCommand
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    // Citim valorile din rândul curent al rezultatelor și le asignăm variabilelor corespunzătoare
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
                return null; // Dacă nu există niciun rând în rezultate, se returnează null
            }
        }
        #endregion
        #region InsertAccount
        public static void InsertAccount(Account account)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                // Construim instrucțiunea SQL pentru a insera un nou cont în baza de date
                sql = "BEGIN \n insert_account('" + account.Username + "', '" + account.Password + "', '" + account.Nume + "'," +
                    " ' " + account.Prenume + "', '" + account.CNP + "', ' " + account.Email + "'," +
                " ' " + account.Address + "', '" + account.City + "', '" + account.PhoneNumber + "', 0, 0); \n END;";

                OracleCommand command = new OracleCommand(sql, connection); // Creăm un obiect OracleCommand pentru a executa instrucțiunea SQL
                command.Connection.Open(); // Deschidem conexiunea către baza de date utilizând obiectul OracleCommand

                command.ExecuteReader(); // Execută instrucțiunea SQL folosind ExecuteReader pentru a insera contul în baza de date
            }
        }
        #endregion
    }
}
