using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BooksContext _context;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookAuthorRepository> _bookAuthorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(BooksContext context)
        {
            _context = context;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(context));
            _bookAuthorRepository = new Lazy<IBookAuthorRepository>(() => new BookAuthorRepository(context));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
        }

        public IAuthorRepository Author => _authorRepository.Value;
        public IBookAuthorRepository BookAuthor => _bookAuthorRepository.Value;
        public IBookRepository Book => _bookRepository.Value;

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
