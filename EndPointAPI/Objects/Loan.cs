using System;

public class Loan
{
    private string _loanId;
    private string _username;
    private string _isbn;
    private DateOnly _issuedDate;
    private DateOnly _returnedDate;

    public string getLoanID() { return _loanId; }
    public void setLoanID(string loanId) { this._loanId = loanId; }
    public string getUsername() { return _username; }
    public void setUserName(string username) { this._username = username; }
    public string getISBN() { return _isbn; }
    public void setISBN(string isbn) { this._isbn = isbn; }

    public DateOnly getIssuedDate() { return _issuedDate; }
    public void setIssuedDate(DateOnly issuedDate) { this._issuedDate = issuedDate; }

    public DateOnly getReturnedDate() { return _returnedDate; }
    public void setReturnedDate(DateOnly returnedDate) { this._returnedDate = returnedDate; }

    public override string ToString()
    {
        return "Book{" +
            "_loanId" + _loanId +
            "_username" + _username +
            "_isbn" + _isbn +
            "_issuedDate" + _issuedDate +
            "_returnedDate" + _returnedDate +
            '}';
    }
}
