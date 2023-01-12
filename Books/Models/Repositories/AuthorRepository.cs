using Books.Models.Domains;
using Microsoft.AspNetCore.Mvc;

namespace Books.Models.Repositories
{
    public class AuthorRepository
    {
        private readonly BooksContext _context;

        public AuthorRepository(BooksContext context)
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

        public Author GetAuthor(string name)
        {

        }
    }
}
