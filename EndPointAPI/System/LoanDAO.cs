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
