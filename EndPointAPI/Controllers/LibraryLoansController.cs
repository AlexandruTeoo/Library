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
        }

        [HttpPut("loans/approve")]
        public IActionResult ApproveLoan([FromBody] string loanId)
        {

            return Ok("Loan approved successfully");
        }

    }
}
