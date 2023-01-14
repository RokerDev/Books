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

        public IEnumerable<Author> GetAllAuthors(bool trackChanges) => FindAll(trackChanges)
            .OrderBy(c => c.LastName)
            .ToList();

    }
}
