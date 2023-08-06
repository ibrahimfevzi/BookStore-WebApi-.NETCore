using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;

using WebApi.DBOperation;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Controllers

{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        // private static List<Book> BookList = new List<Book>()
        // {
        //     new Book() {
        //         Id = 1,
        //         Title = "Lean Startup",
        //         GenreId = 1, // Personal Growth
        //         PageCount = 200,
        //         PublishDate = new System.DateTime(2001, 6, 12)
        //     },

        //     new Book() {
        //         Id = 2,
        //         Title = "Herland",
        //         GenreId = 2, // Science Fiction
        //         PageCount = 200,
        //         PublishDate = new System.DateTime(2010, 5, 23)
        //     },
        //     new Book() {
        //         Id = 3,
        //         Title = "Dune",
        //         GenreId = 2, // Science Fiction
        //         PageCount = 540,
        //         PublishDate = new System.DateTime(2001, 12, 21)
        //     },
        // };  


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        
       [HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var book = _context.Books.FirstOrDefault(x => x.Id == id);

    if (book == null)
    {
        return NotFound(new { message = "Book not found" });
    }

    return Ok(book);
}


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
           CreateBookCommand command = new CreateBookCommand(_context);
           try {
               command.Model = newBook;
               command.Handle();
              }
              catch (Exception ex )
                {
                    return BadRequest(ex.Message);
                    }
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                return BadRequest( new { message = "Book does not exist" });
            }

            book.Title = updatedBook.Title;
            book.GenreId = updatedBook.GenreId;
            book.PageCount = updatedBook.PageCount;
            book.PublishDate = updatedBook.PublishDate;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book =_context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                return BadRequest( new { message = "Book does not exist" });
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}

