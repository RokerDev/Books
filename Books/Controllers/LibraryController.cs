using Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public LibraryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
    }
}
