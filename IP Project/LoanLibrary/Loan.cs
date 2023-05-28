/**************************************************************************
 *                                                                        *
 *  File:        LoanLibrary.dll                                          *
 *  Copyright:   (c) 2023, Alexandru-Teodor Atanase                       *
 *  E-mail:      alexandru-teodor.atanase@student.tuiasi.ro               *
 *  Website:     https://github.com/AlexandruTeoo/IP-Projec               *
 *  Description: Loan.cs (class)                                          *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary
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
