using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers

{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private static List<Book> BookList = new List<Book>()
        {
            new Book() {
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1, // Personal Growth
                PageCount = 200,
                PublishDate = new System.DateTime(2001, 6, 12)
            },

            new Book() {
                Id = 2,
                Title = "Herland",
                GenreId = 2, // Science Fiction
                PageCount = 200,
                PublishDate = new System.DateTime(2010, 5, 23)
            },
            new Book() {
                Id = 3,
                Title = "Dune",
                GenreId = 2, // Science Fiction
                PageCount = 540,
                PublishDate = new System.DateTime(2001, 12, 21)
            },
        };  


        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public List<Book> GetBook(int id)
        {
            var bookList = BookList.Where(x => x.Id == id).ToList<Book>();
            return bookList;
        }

    }   

}