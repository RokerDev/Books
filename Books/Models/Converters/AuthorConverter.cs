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
                Name = model.FirstName + " " + model.LastName,
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
            var firstName = model.Name.Split(' ')[0];
            var lastName = model.Name.Split(' ')[1];

            return new Author
            {
                Id = model.Id,
                BirthDate = model.BirthDate,
                FirstName = firstName,
                LastName = lastName,
                Gender = model.Gender
            };
        }
    }
}
