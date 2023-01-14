using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookAuthorRepository: RepositoryBase<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(BooksContext context)
            :base(context)
        {

        }
    }
}
