using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIP
{
    public class Loan
    {
        #region Getters and Setters
        public int _loanId { get; set; }
        public int _accountId { get; set; }
        public int _isbn { get; set; }
        public DateTime _issuedDate { get; set; }
        public DateTime _returnedDate { get; set; }
        public int _accepted { get; set; }
        #endregion
        #region Constructors
        public Loan()
        {

        }
        public Loan(Loan l)
        {
            _loanId = l._loanId;
            _accountId = l._accountId;
            _isbn = l._isbn;
            _issuedDate = l._issuedDate;
            _returnedDate = l._returnedDate;
            _accepted = l._accepted;
        }

        public Loan(int loanId, int accountId, int isbn, DateTime issuedDate, DateTime returnedDate, int accepted)
        {
            _loanId = loanId;
            _accountId = accountId;
            _isbn = isbn;
            _issuedDate = issuedDate;
            _returnedDate = returnedDate;
            _accepted = accepted;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return "Loan ID: " + _loanId +
                " | Cont ID: " + _accountId +
                " | Carte ISBN: " + _isbn +
                " | Data Imprumut: " + _issuedDate +
                " | Data Restituire: " + _returnedDate +
                " | Acceptat: " + _accepted;
        }
        #endregion
    }
}
