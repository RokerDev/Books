using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Service.Converters;
using Shared.DataTransferObjects;
using System.ComponentModel.Design;

namespace Service
{
    internal sealed class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public BookService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public BookDto CreateBook(BookForCreationDto book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            _repository.Book.CreateBook(bookEntity);
            _repository.Complete();
            var bookDto = _mapper.Map<BookDto>(bookEntity);
            return bookDto;
        }

        public void DeleteBook(int id, bool trackChanges)
        {
            var bookToDelete = _repository.Book.GetBook(id, trackChanges);
            if (bookToDelete == null) 
                throw new BookNotFoundException(id);
            _repository.Book.DeleteBook(bookToDelete);
            _repository.Complete();
        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            var books = _repository.Book.GetAllBooks(trackChanges);
            var booksDto = books.Select(x => x.ToDto()).ToList();
            return booksDto;
        }

        public BookDto GetBook(int id, bool trackChanges)
        {
            var book = _repository.Book.GetBook(id, trackChanges);
            if (book == null) 
                throw new BookNotFoundException(id);

            return book.ToDto();
        }

        public void UpdateBook(int id, BookForUpdateDto bookForUpdate, bool trackChanges)
        {
            var bookEntity = _repository.Book.GetBook(id, trackChanges);
            if (bookEntity == null)
                throw new BookNotFoundException(id);

            _mapper.Map(bookForUpdate, bookEntity);
            _repository.Complete();
        }
    }
}
