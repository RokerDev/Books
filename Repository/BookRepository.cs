using Contracts;
using Entities.Models;

namespace Repository
{
    public class BookRepository: RepositoryBase<Book>, IBookRepository
    {
        private BooksContext _context;
        public BookRepository(BooksContext context)
            : base(context)
        {
            _context= context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public Book Get(string title)
        {
            return _context.Books.FirstOrDefault(x => x.Title.Contains(title));
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            var bookToUpdate = _context.Books.Single(x => x.Id== book.Id);
            bookToUpdate.Isbn = book.Isbn;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Rating= book.Rating;
        }

        public void Delete(int id)
        {
            var bookToRemove = _context.Books.First(x => x.Id == id);
            _context.Books.Remove(bookToRemove);
        }




    }
}
