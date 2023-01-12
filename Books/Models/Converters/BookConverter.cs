using Books.Models.Domains;
using Books.Models.Dtos;

namespace Books.Models.Converters
{
    public static class BookConverter
    {
        public static BookDto ToDto(this Book model)
        {
            return new BookDto
            {
                Id = model.Id,
                Title = model.Title,
                Description= model.Description,
                Isbn= model.Isbn,
                PublicationDate= model.PublicationDate,
                Rating = model.Rating
            };
        }

        public static IEnumerable<BookDto> ToDtos(this IEnumerable<Book> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<BookDto>();
            }
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
