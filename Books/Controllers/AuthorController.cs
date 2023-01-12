using Books.Models;
using Books.Models.Converters;
using Books.Models.Dtos;
using Books.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public AuthorController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public DataResponse<IEnumerable<AuthorDto>> Get()
        {
            var response = new DataResponse<IEnumerable<AuthorDto>>();
            try
            {                
                response.Data = _unitOfWork.Author.GetAll().ToDtos();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));         
            }
            return response;
        }

        [HttpGet("{name}")]
        public DataResponse<AuthorDto> Get(string name)
        {
            var response = new DataResponse<AuthorDto>();
            try
            {
                response.Data = _unitOfWork.Author.Get(name)?.ToDto();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));
            }
            return response;
        }


        [HttpPost]
        public Response Add(AuthorDto author)
        {
            var response = new Response();
            try
            {
                _unitOfWork.Author.Add(author.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));
            }
            return response;
        }
    }
}
