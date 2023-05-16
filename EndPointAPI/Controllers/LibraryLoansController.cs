using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EndPointAPI.Controllers
{
    public class LibraryLoansController : ControllerBase
    {
        [HttpGet("loans")]
        public IActionResult GetLoans(int accountId)
        {
            List <Loan> _loans = LoanDAO.GetLoans();
            var loans = _loans.Where(l => l.getAccountId() == accountId);
            if (loans != null)
            {
                return Ok(loans);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("loans/{id}")]
        public IActionResult GetLoan(string id)
        {
            List<Loan> _loans = LoanDAO.GetLoans();
            
            if (_loans != null)
            {
                return Ok(_loans);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("loans/add")]
        public IActionResult AddLoan([FromBody] Loan loan)
        {
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
        }

        [HttpPut("loans/approve")]
        public IActionResult ApproveLoan([FromBody] string loanId)
        {
            // Approve the loan with the given ID
            Loan approvedLoan = LoanDAO.ApproveLoan(loanId);

            if (approvedLoan == null)
            {
                return BadRequest("Loan not found or already approved");
            }

            // Update the book availability status
            

            return Ok("Loan approved successfully");
        }

    }
}
