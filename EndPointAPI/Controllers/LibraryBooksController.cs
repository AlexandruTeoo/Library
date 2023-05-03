using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EndPointAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryBooksController : ControllerBase
    {
        /*private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };*/

        /*private readonly ILogger<LibraryBooksController> _logger;

        public LibraryBooksController(ILogger<LibraryBooksController> logger)
        {
            _logger = logger;
        }*/

        private static List<Book> _books = new List<Book>
        {
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Category = "Fiction", ISBN = "9780142437419", Stock = 2, Total = 3},
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Category = "Fiction", ISBN = "9780446310789", Stock = 2, Total = 3 },
            new Book { Title = "1984", Author = "George Orwell", Category = "Fiction", ISBN = "9780451524935" , Stock = 2, Total = 3},
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Category = "Romance ", ISBN = "9780141439518" , Stock = 2, Total = 3},
            new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Category = "Fiction", ISBN = "9780316769174" , Stock = 2, Total = 3},
            new Book { Title = "Amintiri din copilarie", Author = "Ion Creanga", Category = "Biography", ISBN = "9780316769175" , Stock = 0, Total = 3},
            new Book { Title = "Ion", Author = "Liviu Rebreanu", Category = "Fiction", ISBN = "9780316769188" , Stock = 2, Total = 3},
            new Book { Title = "Fluturi de noapte", Author = "Otilia Cazimir", Category = "Romance ", ISBN = "9780316769199" , Stock = 2, Total = 3},
            new Book { Title = "Enigma Otiliei", Author = "George Calinescu", Category = "Mystery", ISBN = "9780316769100", Stock = 2, Total = 3 }
        };

        [HttpGet("books")]
        public IActionResult GetBooks(string contains = null)
        {
            if (!string.IsNullOrEmpty(contains))
            {
                var books = _books.Where(b =>
                    b.Author.ToLower().Contains(contains.ToLower()) ||
                    b.Title.ToLower().Contains(contains.ToLower())
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
            var book = _books.FirstOrDefault(b => b.ISBN == isbn);
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
            var book = _books.Where(b => b.Category == category);
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
            Book book = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null && book.Stock > 0)
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

            return CreatedAtRoute("GetBook", new { isbn = _book.ISBN }, _book);
        }
    }
}