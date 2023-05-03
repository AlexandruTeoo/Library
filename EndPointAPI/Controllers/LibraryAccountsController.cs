using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace EndPointAPI.Controllers
{
    public class LibraryAccountsController : ControllerBase
    {
        private static List<Account> _accounts = new List<Account>
        {
            new Account{ Id = 1, Username = "matei.rares", Password = "qweasdzxc", AccountType = "User"},
            new Account{ Id = 2, Username = "radu.dumitriu", Password = "qweasdzxc", AccountType = "Admin"},
            new Account{ Id = 3, Username = "mihai.nejneriu", Password = "qweasdzxc", AccountType = "User"},
            new Account{ Id = 4, Username = "ovi.catarama", Password = "qweasdzxc", AccountType = "User"},
            new Account{ Id = 5, Username = "teodor.alexandru", Password = "qweasdzxc", AccountType = "Admin"}
        };

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] Account account)
        {
            // Find the user by username and password
            Account acc = _accounts.FirstOrDefault(a => 
            a.Username == account.Username &&
            a.Password == account.Password); // email ??

            // Check if the user exists
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

            // Check if the username already exists
            if (_accounts.Any(u => u.Username == account.Username))
            {
                return Conflict();
            }

            // Create a new user object
            Account acc = new Account
            {
                Id = _accounts.Count + 1,
                Username = account.Username,
                Password = account.Password,
                Nume = account.Nume,
                Prenume = account.Prenume,
                Email = account.Email,
                AccountType = "User",
            };

            // Add the user to the list of users
            _accounts.Add(acc);

            // Return the newly created user object
            return CreatedAtAction(nameof(LogIn), new { id = acc.Id }, acc);
        }

        [HttpGet("accounttype")]
        public IActionResult GetAccount(string username, string passwd)
        {
            var acc = _accounts.FirstOrDefault(a => a.Username == username && a.Password == passwd);
            if (acc != null)
            {
                return Ok(acc.AccountType);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("updateuser/{id}/user")]
        public IActionResult UpdateUser(int id, [FromBody] Account newUserData)
        {
            // Find the user by Id
            Account acc = _accounts.FirstOrDefault(u => u.Id == id);

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
