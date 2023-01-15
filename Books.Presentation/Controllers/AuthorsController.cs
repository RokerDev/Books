using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id) 
        {
            var company = _service.AuthorService.GetAuthor(id, trackChanges: false);
            return Ok(company);
        }

    }
}
