using Books.Models;
using Books.Models.Converters;
using Books.Models.Dtos;
using Books.Models.Response;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private ILoggerManager _logger;
        public BookController(UnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork= unitOfWork;
            _logger= logger;
        }

        [HttpGet]
        public DataResponse<IEnumerable<BookDto>> Get()
        {
            var response = new DataResponse<IEnumerable<BookDto>>();
            try
            {
                response.Data = _unitOfWork.Book.GetAll().ToDtos();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));
            }
            return response;
        }

        [HttpGet("{title}")]
        public DataResponse<BookDto> Get(string title)
        {
            var response = new DataResponse<BookDto>();
            try
            {
                response.Data = _unitOfWork.Book.Get(title)?.ToDto();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));
            }
            return response;
        }


        [HttpPost]
        public Response Add(BookDto book)
        {
            var response = new Response();
            try
            {
                _unitOfWork.Book.Add(book.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));
            }
            return response;
        }

        [HttpPut]
        public Response Update(BookDto book)
        {
            var response = new Response();
            try
            {
                _unitOfWork.Book.Update(book.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Message, exception.Source));
            }
            return response;
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();
            try
            {
                _unitOfWork.Book.Delete(id);
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

