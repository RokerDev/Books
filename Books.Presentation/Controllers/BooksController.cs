using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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

        [HttpGet("{id}", Name ="GetBookById")]
        public IActionResult GetBooks(int id)
        {
            var book = _service.BookService.GetBook(id, trackChanges: false);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody]BookForCreationDto book)
        {
            if (book is null)
                return BadRequest("BookForCreation object is null");
            var bookToReturn = _service.BookService.CreateBook(book);
            return CreatedAtRoute("GetBookById", new { id = bookToReturn.Id }, bookToReturn);
        }


    }

}
