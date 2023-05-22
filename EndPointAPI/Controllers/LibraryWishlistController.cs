using EndPointAPI.System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EndPointAPI.Controllers
{
    public class LibraryWishlistController : Controller
    {
        [HttpGet("wishlist")]
        public IActionResult GetWishlist(int accountId)
        {
            List<Wishlist> _wishlist = WishlistDAO.GetWishlistByAcc(accountId);
            //var wishlist = _wishlist.Where(l => l._accountId == accountId);
            if (_wishlist != null)
            {
                return Ok(_wishlist);
            }
            return NotFound();
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("wishlist/add")]
        public IActionResult AddBookWishlist([FromBody] Wishlist wishlist)
        {
            int status = WishlistDAO.AddBookWishlist(wishlist);

            switch (status)
            {
                case -1:
                    return NotFound("User not found."); // ca sa adaugi cartea in wishlist trebuie sa fi logat, deci user ul deja exista
                case 0:
                    return Ok(wishlist);
                default:
                    return NotFound("[AddBookWishlist]Internal Err");
            }
        }
        [EnableCors("AllowOrigin")]
        [HttpDelete("delete_wishlist")]
        public IActionResult DeleteWishlist([FromBody] Wishlist wishlist)
        {
            WishlistDAO.DeleteBookWishlist(wishlist);
            return Ok();
        }
    }
}
