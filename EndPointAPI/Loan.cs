namespace EndPointAPI
{
    public class Loan
    {
        private string _loanId;
        private int _accountId;
        private string _isbn;
        private DateOnly _issuedDate;
        private DateOnly _returnedDate;

        public Loan (Loan l)
        {
            _loanId = l._loanId;
            _accountId = l._accountId;
            _isbn = l._isbn;
            _issuedDate = l._issuedDate;
            _returnedDate = l._returnedDate;
        }

        public string getLoanID() { return _loanId; }
        public void setLoanID(string loanId) { this._loanId = loanId; }
        
        public int getAccountId() { return _accountId; }
        public void setAccountId(int accountId) { this._accountId = accountId; }
        
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
                "_username" + _accountId +
                "_isbn" + _isbn +
                "_issuedDate" + _issuedDate +
                "_returnedDate" + _returnedDate +
                '}';
        }
    }
}
