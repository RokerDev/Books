using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Presentation.Controllers
{
    [Route("api/books/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BooksController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _service.BookService.GetAllBooks(trackChanges: false);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooks(int id)
        {
            var book = _service.BookService.GetBook(id, trackChanges: false);

            return Ok(book);
        }

    }

}
