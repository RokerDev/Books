namespace Repository
{
    public class RepositoryManager
    {
        private BooksContext _context;
        public RepositoryManager(BooksContext context)
        {
            _context = context;
            Author = new AuthorRepository(context);
            Book = new BookRepository(context);
        }

        public AuthorRepository Author { get; set; }
        public BookRepository Book { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
