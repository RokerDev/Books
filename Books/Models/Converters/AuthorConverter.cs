using Books.Models.Domains;
using Books.Models.Dtos;

namespace Books.Models.Converters
{
    public static class AuthorConverter
    {
        public static AuthorDto ToDto(this Author model)
        {
            return new AuthorDto
            {
                Id = model.Id,
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender
            };
        }

        public static IEnumerable<AuthorDto> ToDtos(this IEnumerable<Author> model) 
        {
            if (model == null)
            {
                return Enumerable.Empty<AuthorDto>();
            }
            return model.Select(x => x.ToDto());
        }

        public static Author ToDao(this AuthorDto model) 
        {
            return new Author
            {
                Id = model.Id,
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender
            };
        }
    }
}
