using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace EndPointAPI.Controllers
{
    public class LibraryAccountsController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult LogIn([FromBody] Account account)
        {
            List<Account> _accounts = AccountDAO.GetAccounts();
            // Find the user by username and password
            Account acc = _accounts.FirstOrDefault(a => 
            a.getUsername() == account.getUsername() &&
            a.getPassword() == account.getPassword()); // email ??
            
            // Check if the user exists -> nu. Asta se verifica deja in functia insertaccount.
            if (acc == null)
            {
                return NotFound();
            }

            // Return the user object
            return Ok(acc);

            //return CreatedAtRoute("GetAccount", new { id = _account.Id }, _account); // ??
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Account account)
        {
            List<Account> _accounts = AccountDAO.GetAccounts();

            // Check if the username already exists
            if (_accounts.Any(u => u.getUsername() == account.getUsername()))
            {
                return Conflict();
            }

            // Create a new user object
            Account newAcc = new Account (account);
            

            // Add the user to the list of users
            _accounts.Add(newAcc);

            // Return the newly created user object
            return CreatedAtAction(nameof(LogIn), new { id = newAcc.getId() }, newAcc);
        }

        [HttpGet("accounttype")]
        public IActionResult GetAccount(string username, string passwd)
        {

            List<Account> _accounts = AccountDAO.GetAccounts();
            var acc = _accounts.FirstOrDefault(a => a.getUsername() == username && a.getPassword() == passwd);
            if (acc != null)
            {
                return Ok(acc.getAccountType());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("updateuser/{id}/user")]
        public IActionResult UpdateUser(int id, [FromBody] Account newUserData)
        {

            List<Account> _accounts = AccountDAO.GetAccounts();

            // Find the user by Id
            Account acc = _accounts.FirstOrDefault(u => u.getId() == id);

            // Check if the user exists
            if (acc == null)
            {
                return NotFound();
            }

            // Update the user's data
            acc = newUserData;

            return Ok(acc);
        }
    }
}
