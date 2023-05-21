using EndPointAPI;
using Oracle.ManagedDataAccess.Client;
using System;

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

            if (dataReader.Read())
            {
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
            return null;

        }
    }
    //trebuie refacut cum e ala din bookdao. e usor de facut
    public static Loan GetLoan (int loanId)
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

    public static List<Loan> GetAllLoans()
    {
        using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
        {
            String sql;
            sql = "Select * from LOAN";

            OracleCommand command = new OracleCommand(sql, connection);

            command.Connection.Open();
            OracleDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
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
            return null;
        }
    }
    
    /*public static bool IsBookAvailable(int isbn)
    {
        // Find the book with the given ID
        List<Book> _books = BookDAO.GetBooks();
        //List<Book> _books = new List<Book>(BookDAO.GetBooks());
        //_books = BookDAO.GetBooks();

        List<Loan> _loans = LoanDAO.GetAllLoans();
        //List <Loan> _loans = new List<Loan>(GetLoans());
        //_loans = GetLoans();

        Book book = _books.FirstOrDefault(b => b.getISBN() == isbn);

        // If the book is not found, it is not available
        if (book == null)
        {
            return false;
        }

        // Check if the book is currently on loan
        return _loans.Any(loan => loan.getISBN() == isbn && loan.getReturnedDate() == null);
    }*/

    /*public static bool UserExists(int accountId)
    {
        List<Loan> _loans = LoanDAO.GetAllLoans();
        //List<Loan> _loans = new List<Loan>(GetLoans());
        // Loop through the accounts list and check if there's an account with the provided username
        foreach (Loan l in _loans)
        {
            if (l._accountId == accountId)
            {
                return true;
            }
        }
        return false;
    }*/

    public static void ApproveLoan (string loanId) // de terminat
    {
        try
        {
            using (OracleConnection connection = new OracleConnection(Database.GetConnectionString()))
            {
                String sql;
                sql = "BEGIN accept_loan(" + loanId + ") END;";
                OracleCommand command = new OracleCommand(sql, connection);

                command.Connection.Open();
                OracleDataReader dataReader = command.ExecuteReader();
            }
        }
        catch (OracleException ex)
        {
            int errorCode = ex.Number;
            string errorMessage = ex.Message;

            if (errorCode == -20003)
            {
                //return -1;
            }
            else if (errorCode == -21001)
            {
                
            }
        }
    }
    
    public static int AddLoan (Loan loan)
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