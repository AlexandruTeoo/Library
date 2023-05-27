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
        public int LoanId { get; set; }
        public int AccountId { get; set; }
        public int ISBN { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public int Accepted { get; set; }
        #endregion
        #region Constructors
        public Loan()  // constructor
        {

        }
        public Loan(Loan l) // constructor
        {
            LoanId = l.LoanId;
            AccountId = l.AccountId;
            ISBN = l.ISBN;
            IssuedDate = l.IssuedDate;
            ReturnedDate = l.ReturnedDate;
            Accepted = l.Accepted;
        }

        public Loan(int loanId, int accountId, int isbn, DateTime issuedDate, DateTime returnedDate, int accepted) // constructor
        {
            LoanId = loanId;
            AccountId = accountId;
            ISBN = isbn;
            IssuedDate = issuedDate;
            ReturnedDate = returnedDate;
            Accepted = accepted;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return "Loan ID: " + LoanId +
                " | Cont ID: " + AccountId +
                " | Carte ISBN: " + ISBN +
                " | Data Imprumut: " + IssuedDate +
                " | Data Restituire: " + ReturnedDate +
                " | Acceptat: " + Accepted;
        }
        #endregion
    }
}
