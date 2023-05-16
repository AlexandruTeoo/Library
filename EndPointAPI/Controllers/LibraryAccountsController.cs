using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace EndPointAPI.Controllers
{
    public class LibraryAccountsController : ControllerBase
    {
        [EnableCors("AllowOrigin")]
        [HttpPost("login")]
        public IActionResult LogIn([FromBody] Account account)
        {
            Account acc = AccountDAO.GetAccount(account._username, account._password); 
            
            if (acc == null)
            {
                return NotFound();
            }

            return Ok(acc);

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Account account)
        {
            return Ok("Salut");
        }

        [HttpGet("accounttype")]
        public IActionResult GetAccount(string username, string passwd)
        {

            return Ok("Salut");
        }

        [HttpPut("updateuser/{id}/user")]
        public IActionResult UpdateUser(int id, [FromBody] Account newUserData)
        {

            return Ok("Salut");
        }
    }
}
