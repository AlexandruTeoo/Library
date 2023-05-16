using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EndPointAPI.Controllers
{
    public class LibraryLoansController : ControllerBase
    {
        [HttpGet("loans/{accountId}")]
        public IActionResult GetLoans(int accountId)
        {
            List <Loan> _loans = LoanDAO.GetLoans(accountId);
            var loans = _loans.Where(l => l.getAccountId() == accountId);
            if (loans != null)
            {
                return Ok(loans);
            }
            return NotFound();
        }

        [HttpGet("all_loans")]
        public IActionResult GetAllLoans(int accountId)
        {
            List<Loan> _loans = LoanDAO.GetAllLoans();
            var loans = _loans.Where(l => l.getAccountId() == accountId);
            if (loans != null)
            {
                return Ok(loans);
            }
            return NotFound();
        }

        [HttpGet("loan/{loanId}")]
        public IActionResult GetLoan(int loanId)
        {
            Loan _loan = LoanDAO.GetLoan(loanId);
            
            if (_loan != null)
            {
                return Ok(_loan);
            }
            return NotFound();
        }

        [HttpPost("loans/add")]
        public IActionResult AddLoan([FromBody] Loan loan)
        {
<<<<<<< Updated upstream
            // Check if the book is available
            

            // Check if the user exists
            if (!LoanDAO.UserExists(loan.getAccountId())) // ?? sql
            {
                return NotFound("User not found.");
            }

            // Create a new loan object
            /*loan.setLoanID(_loans.Count + 1);
            loan.setIssuedDate(DateOnly.FromDateTime(DateTime.UtcNow.Date));
            loan.setReturnedDate(loan.getIssuedDate().AddDays(14));*/
            LoanDAO.AddLoan(loan);

            // Return the newly created loan object
            return CreatedAtAction(nameof(GetLoan), new { id = loan.getLoanID() }, loan);
=======
            int status = LoanDAO.AddLoan(loan);

            switch(status)
            {
                case -1:
                    return Conflict("Book is not available for loan.");
                case -2: 
                    return NotFound("User not found.");
                case 0:
                    return Ok(loan);
                default:
                    return NotFound("[AddLoan]Internal Err");
            }
>>>>>>> Stashed changes
        }

        [HttpPut("loans/approve")]
        public IActionResult ApproveLoan([FromBody] string loanId)
        {
            // Approve the loan with the given ID
<<<<<<< Updated upstream
            Loan approvedLoan = LoanDAO.ApproveLoan(loanId);

            if (approvedLoan == null)
            {
                return BadRequest("Loan not found or already approved");
            }

            // Update the book availability status
            
=======
            LoanDAO.ApproveLoan(loanId);
>>>>>>> Stashed changes

            return Ok("Loan approved successfully");
        }

    }
}
