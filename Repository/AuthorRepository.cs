using Contracts;
using Entities.Models;

namespace Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly BooksContext _context;

        public AuthorRepository(BooksContext context)
            : base(context)
        {
            _context= context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public Author Get(string name) 
        {
            var firstName = name.Split(' ')[0];
            var lastName = name.Split(' ')[1];
            return _context.Authors.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
        }

    }
}
