using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EndPointAPI.Controllers
{
    public class LibraryLoansController : ControllerBase
    {
        private static List<Loan> _loans = new List<Loan>
        {
            new Loan{ LoanId = 1, Username = "matei.rares", ISBN = "9780142437419" },
            new Loan{ LoanId = 2, Username = "matei.rares", ISBN = "9780451524935" },
            new Loan{ LoanId = 3, Username = "mihai.nejneriu", ISBN = "9780316769175" },
            new Loan{ LoanId = 4, Username = "ovi.catarama", ISBN = "9780316769175" },
            new Loan{ LoanId = 5, Username = "ovi.catarama", ISBN = "9780316769100" }
        };

        [HttpGet("loans")]
        public IActionResult GetLoans(string user)
        {
            var loans = _loans.Where(l => l.Username == user);
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
        public IActionResult GetLoan(int id)
        {
            var loan = _loans.FirstOrDefault(l => l.LoanId == id);
            if (loan != null)
            {
                return Ok(loan);
            }
            else
            {
                return NotFound();
            }
        }

        /*[HttpPost("loans/add")]
        public IActionResult AddLoan([FromBody] Loan loan)
        {
            // Check if the book is available
            if (!IsBookAvailable(loan.ISBN)) // ?? sql
            {
                return Conflict("Book is not available for loan.");
            }

            // Check if the user exists
            if (!UserExists(loan.Username)) // ?? sql
            {
                return NotFound("User not found.");
            }

            // Create a new loan object
            loan.LoanId = _loans.Count + 1;
            loan.IssuedDate = DateOnly.FromDateTime(DateTime.UtcNow.Date);
            loan.ReturnedDate = loan.IssuedDate.AddDays(14);

            // Add the loan to the list of loans
            _loans.Add(loan);

            // Update the book availability status
            UpdateBookAvailability(loan.LoanId, false); // ? sql

            // Return the newly created loan object
            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, loan);
        }

        [HttpPut("loans/approve")]
        public IActionResult ApproveLoan([FromBody] int loanId)
        {
            // Approve the loan with the given ID
            Loan approvedLoan = ApproveLoan(loanId);

            if (approvedLoan == null)
            {
                return BadRequest("Loan not found or already approved");
            }

            // Update the book availability status
            UpdateBookAvailability(approvedLoan.BookId, false);

            return Ok("Loan approved successfully");
        }*/

    }
}
