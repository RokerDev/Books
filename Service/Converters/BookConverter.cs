using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Converters
{
    public static class BookConverter
    {
        public static BookDto ToDto(this Book model)
        {
            return new BookDto
            {
                Id = model.Id,
                Title= model.Title,
                Description= model.Description, 
                Isbn= model.Isbn,
                PublicationDate= model.PublicationDate,
                Rating = model.Rating               
            };
        }

        public static IEnumerable<BookDto> ToDtos(this IEnumerable<Book> model)
        {
            return model.Select(x => x.ToDto());
        }

        public static Book ToDao(this BookDto model)
        {
            return new Book
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Isbn = model.Isbn,
                PublicationDate = model.PublicationDate,
                Rating = model.Rating
            };
        }
    }
}
