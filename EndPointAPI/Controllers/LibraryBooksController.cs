using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace EndPointAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryBooksController : ControllerBase
    {
        [HttpGet("books")]
        public IActionResult GetBooks(string contains = null)
        {
            List<Book> _books = BookDAO.GetBooks();
            if (!string.IsNullOrEmpty(contains))
            {
                var books = _books.Where(b =>
                    b.getAuthor().ToLower().Contains(contains.ToLower()) ||
                    b.getTitle().ToLower().Contains(contains.ToLower())
                );
                return Ok(books);
            }
            else
            {
                return Ok(_books);
            }
        }

        [HttpGet("book/{isbn}")]
        public IActionResult GetBook(string isbn)
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
        public IActionResult CheckStock(string isbn)
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

            return CreatedAtRoute("GetBook", new { isbn = _book.getISBN() }, _book);
        }
    }
}