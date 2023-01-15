using Contracts;
using Entities.Models;
using System.ComponentModel.Design;

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

        public void CreateAuthor(Author author) => Create(author);

        public IEnumerable<Author> GetAllAuthors(bool trackChanges) => FindAll(trackChanges)
            .OrderBy(c => c.LastName)
            .ToList();

        public Author GetAuthor(int id, bool trackChanges) => 
            FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
