using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class LoanDAO
    {
        public static List<Loan> GetLoans(int accId)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "Select * from LOAN WHERE account_id = '" + accId + "'";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                List<Loan> loans = new List<Loan>();
                while (dataReader.Read())
                {
                    Loan loan = new Loan(
                        dataReader.GetString(0),
                        dataReader.GetInt32(1),
                        dataReader.GetInt32(2),
                        dataReader.GetDateTime(3).Date,
                        dataReader.GetDateTime(4).Date
                    );

                    loans.Add(loan);
                }
                return loans;
            }
        }

        public static List<Loan> GetAllLoans()
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "Select * from LOAN where accepted = 0";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                List<Loan> loans = new List<Loan>();

                while (dataReader.Read())
                {
                    Loan loan = new Loan(
                        dataReader.GetString(0),
                        dataReader.GetInt32(1),
                        dataReader.GetInt32(2),
                        dataReader.GetDateTime(3).Date,
                        dataReader.GetDateTime(4).Date
                    );

                    loans.Add(loan);
                }

                return loans;
  
            }
        }

        public static void ApproveLoan(string loanId) // de terminat 
            //Cand apelezi faci try{metoda asta} catch{ce ai facut aici}
        {
            //try
            //{
                using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
                {
                    String sql;
                    sql = "BEGIN \n accept_loan(" + loanId + "); \n END;";
                    OracleCommand command = new OracleCommand(sql, connection);

                    command.Connection.Open();
                    command.ExecuteReader();
                }
                /*
            }
            
            catch (OracleException ex)
            {
                int errorCode = ex.Number;
                string errorMessage = ex.Message;

                if (errorCode == -20003)
                {
                    return -1;
                }
                if (errorCode == -21001)
                {
                    return -2;
                }
                return -3;
            }
                */
        }

        public static int AddLoan(Loan loan)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;

                sql = "CREATE OR REPLACE PROCEDURE insert_loan(" +
                                                loan._accountId + "," +
                                                loan._isbn + "," +
                                                loan._issuedDate + "," +
                                                loan._returnedDate + ")";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (dataReader.GetInt32(1) == null)
                    {
                        return -2; // acc not found -> trebuie verificat cu loan._accountId in sql??
                    }
                    return 0;
                }
                return -1;
            }
        }
    }
}
