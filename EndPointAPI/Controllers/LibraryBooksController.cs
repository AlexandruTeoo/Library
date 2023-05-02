using Microsoft.AspNetCore.Mvc;

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
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780142437419" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780446310789" },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", ISBN = "9780451524935" },
            new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518" },
            new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769174" },
            new Book { Id = 6, Title = "Amintiri din copilarie", Author = "Ion Creanga", ISBN = "9780316769175" },
            new Book { Id = 7, Title = "Ion", Author = "Liviu Rebreanu", ISBN = "9780316769188" },
            new Book { Id = 8, Title = "Fluturi de noapte", Author = "Otilia Cazimir", ISBN = "9780316769199" },
            new Book { Id = 9, Title = "Enigma Otiliei", Author = "George Calinescu", ISBN = "9780316769100" }
        };

        [HttpGet("books")]
        public IActionResult GetBooks(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var books = _books.Where(b =>
                    b.Author.ToLower().Contains(query.ToLower()) ||
                    b.Title.ToLower().Contains(query.ToLower())
                );
                return Ok(books);
            }
            else
            {
                return Ok(_books);
            }
        }

        [HttpGet("book/{isbn}")]
        public IActionResult GetBookByISBN(string isbn)
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
    }
}