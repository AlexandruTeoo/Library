namespace EndPointAPI
{
    public class Loan
    {
        public string _loanId { get; set; }
        public int _accountId { get; set; }
        public int _isbn { get; set; }
        public DateTime _issuedDate { get; set; }
        public DateTime _returnedDate { get; set; }

        public Loan (Loan l)
        {
            _loanId = l._loanId;
            _accountId = l._accountId;
            _isbn = l._isbn;
            _issuedDate = l._issuedDate;
            _returnedDate = l._returnedDate;
        }

        public Loan (string loanId, int accountId, int isbn, DateTime issuedDate, DateTime returnedDate)
        {
            _loanId = loanId;
            _accountId = accountId;
            _isbn = isbn;
            _issuedDate = issuedDate;
            _returnedDate = returnedDate;
        }
    }
}
