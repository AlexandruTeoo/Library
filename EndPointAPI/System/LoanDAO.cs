using EndPointAPI;
using System;

public class LoanDAO
{
	public static List<Loan> GetLoans()
	{
        List<Loan> _loans = new List<Loan>
        {
            //
        };
        return _loans;
    }

    public static bool IsBookAvailable(string isbn)
    {
        // Find the book with the given ID
        Book book = _books.FirstOrDefault(b => b.getISBN() == isbn);

        // If the book is not found, it is not available
        if (book == null)
        {
            return false;
        }

        // Check if the book is currently on loan
        return _loans.Any(loan => loan.getISBN() == isbn && loan.ReturnedDate == null);
    }

    public static bool UserExists(int accountId)
    {
        //List<Loan> _loans = ;
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

    public static void UpdateBookAvailability(string isbn, bool availability)
    {
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
}
