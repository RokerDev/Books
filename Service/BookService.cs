﻿using Contracts;
using Entities.Exceptions;
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

        public BookService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;

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
    }
}
