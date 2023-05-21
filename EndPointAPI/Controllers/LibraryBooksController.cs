using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EndPointAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryBooksController : ControllerBase
    {
        // AICI TREBUIE FACUTE MAI MULTE API-URI IN LOC DE UNUL SINGUR CARE FILTREAZA.
        // AICI VB CU RADU, CA EL VREA SA FILTREZE PE MAI MULTE CATEGORII.
        [HttpGet("books")]
        public IActionResult GetBooks(string contains = null)
        {
            List<Book> books = BookDAO.GetBooks();
            //_books va trebuie sa fie o lista de carti. Trebuie facut ceva cu JSON.stringify() ca sa transformi
            // lista in string si pe asta o returnezi in caz de ok. Daca lista e goala returnezi cu notfound sau cv
            if (books == null)
            {
                return NotFound();
            }
            
            return Ok(books);
        }
        //toate astea o sa mearga cand o sa fie facut bookdao api sa returneze carti in loc de string.
        /*
        [HttpGet("book/{isbn}")]
        public IActionResult GetBook(int isbn)
        {
            List<Book> _books = BookDAO.GetBooks();
            var book = _books.FirstOrDefault(b => b.getISBN() == isbn);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("categorybooks/{category}")]
        public IActionResult GetCategoryBooks(string category)
        {
            List<Book> _books = BookDAO.GetBooks();
            var book = _books.Where(b => b.getCategory() == category);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("checkstock/{isbn}")]
        public IActionResult CheckStock(int isbn)
        {
            List<Book> _books = BookDAO.GetBooks();
            Book book = _books.FirstOrDefault(b => b.getISBN() == isbn);
            if (book != null && book.getStock() > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("addbooks")]
        public IActionResult AddBook([FromBody] Book _book)
        {
            // Code to add the book to the database or list of books goes here
            int status = BookDAO.AddBook(_book);
            if (status == 0)
            {
                return Ok();
            }
            return NotFound();
            
            //return CreatedAtRoute("GetBook", new { isbn = _book.getISBN() }, _book);
        }
        */
    }
}