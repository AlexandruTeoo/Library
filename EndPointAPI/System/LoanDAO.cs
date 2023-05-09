using EndPointAPI;
using Oracle.ManagedDataAccess.Client;
using System;

public class LoanDAO
{
	public static List<Loan> GetLoans()
	{
        List<Loan> _loans = new List<Loan>();

        OracleConnection con = Database.GetConnection();

        OracleCommand command;
        OracleDataReader dataReader;
        String sql, Output = "";

        sql = "Select * from LOAN";
        command = new OracleCommand(sql, con);
        dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            Loan loan = new Loan(dataReader.GetValue(0).ToString(),
                                Convert.ToInt32(dataReader.GetValue(1)),
                                Convert.ToInt32(dataReader.GetValue(2)),
                                DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetValue(3))),
                                DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetValue(4))));
            _loans.Add(loan);
        }

        Database.ClosedConnection();

        return _loans;
    }

    public static bool IsBookAvailable(int isbn)
    {
        // Find the book with the given ID
        List<Book> _books = BookDAO.GetBooks();
        //List<Book> _books = new List<Book>(BookDAO.GetBooks());
        //_books = BookDAO.GetBooks();

        List<Loan> _loans = LoanDAO.GetLoans();
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
    }

    public static bool UserExists(int accountId)
    {
        List<Loan> _loans = LoanDAO.GetLoans();
        //List<Loan> _loans = new List<Loan>(GetLoans());
        // Loop through the accounts list and check if there's an account with the provided username
        foreach (Loan l in _loans)
        {
            if (l.getAccountId() == accountId)
            {
                return true;
            }
        }
        return false;
    }

    public static void UpdateBookAvailability(int isbn, bool availability)
    {
        List<Book> _books = BookDAO.GetBooks();

        foreach (Book b in _books)
        {
            if (b.getISBN() == isbn)
            {
                if (availability == true)
                {
                    b.setStock(b.getStock() - 1);
                }
                else
                {
                    b.setStock(b.getStock() + 1);
                }
            }
        }
    }

    public static Loan ApproveLoan (string loanId) // de terminat
    {
        List<Loan> _loans = LoanDAO.GetLoans();
        //List<Loan> _loans = new List<Loan>(GetLoans());

        bool approved = false;

        foreach (Loan l in _loans) 
        {
            if (l.getLoanID() == loanId)
            {
                return null;
            }
        }
        return null;
    }

    public static Loan AddLoan (Loan loan)
    {
        OracleConnection con = Database.GetConnection();

        OracleCommand command;
        OracleDataReader dataReader;
        String sql, Output = "";

        sql = "CREATE OR REPLACE PROCEDURE insert_loan(" + 
            loan.getAccountId() + "," + 
            loan.getISBN() + "," + 
            loan.getIssuedDate() + "," + 
            loan.getReturnedDate() +")";

        command = new OracleCommand(sql, con);
        dataReader = command.ExecuteReader();

        Loan _loan = new Loan(dataReader.GetValue(0).ToString(),
                                Convert.ToInt32(dataReader.GetValue(1)),
                                Convert.ToInt32(dataReader.GetValue(2)),
                                DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetValue(3))),
                                DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetValue(4))));

        Database.ClosedConnection();

        return _loan;
    }
}
