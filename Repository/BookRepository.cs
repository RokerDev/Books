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

        public IEnumerable<Book> GetAllBooks(bool trackChanges) => 
            FindAll(trackChanges)
            .OrderBy(x => x.Title).ToList();


        public Book GetBook(int id, bool trackChanges) => 
            FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefault();

    }
}
