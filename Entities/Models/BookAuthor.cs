using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }



        public ICollection<Author> Author { get; set; } = null!;

        public ICollection<Book> Book { get; set; } = null!;
    }
}
