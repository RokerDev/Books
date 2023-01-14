using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IBookAuthorService> _bookAuthorService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger)
        {
            _authorService = new Lazy<IAuthorService>(() => new
            AuthorService(repositoryManager, logger));
            _bookService = new Lazy<IBookService>(() => new
            BookService(repositoryManager, logger));
            _bookAuthorService = new Lazy<IBookAuthorService>(() => new
            BookAuthorService(repositoryManager, logger));
        }
        public IAuthorService AuthorService => _authorService.Value;
        public IBookService BookService => _bookService.Value;
        public IBookAuthorService bookAuthorService => _bookAuthorService.Value;
    }
}
