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

        /*
        public static Loan GetLoan(int loanId)
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "Select * from LOAN WHERE loan_id = '" + loanId + "'";

                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    Loan loan = new Loan(dataReader.GetString(0),
                                        dataReader.GetInt32(1),
                                        dataReader.GetInt32(2),
                                        dataReader.GetDateTime(3).Date,
                                        dataReader.GetDateTime(4).Date);

                    return loan;
                }
                return null;
            }
        }
        */

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

        public static int ApproveLoan(string loanId) // de terminat
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
                {
                    String sql;
                    sql = "BEGIN accept_loan(" + loanId + ") END;";
                    OracleCommand command = new OracleCommand(sql, connection);

                    /*command.Connection.Open();
                    OracleDataReader dataReader = command.ExecuteReader();*/

                    return 0;
                }
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
