using Books.Models.Repositories;

namespace Books.Models
{
    public class UnitOfWork
    {
        private BooksContext _context;
        public UnitOfWork(BooksContext context)
        {
            _context = context;
            Author = new AuthorRepository(context);
        }

        public AuthorRepository Author { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
