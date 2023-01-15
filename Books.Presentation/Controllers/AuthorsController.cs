using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Books.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthorsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _service.AuthorService.GetAllAuthors(trackChanges: false);
            return Ok(authors);
        }

        [HttpGet("{id}", Name = "AuthorById")]
        public IActionResult GetAuthor(int id) 
        {
            var author = _service.AuthorService.GetAuthor(id, trackChanges: false);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            if (author is null)
                return BadRequest("AuthorForCreationDto object is null");
            var createdAuthor = _service.AuthorService.CreateAuthor(author);
            return CreatedAtRoute("AuthorById", new { id = createdAuthor.Id }, createdAuthor);
        }


    }
}
