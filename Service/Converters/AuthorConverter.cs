using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Converters
{
    public static class AuthorConverter
    {
        public static AuthorDto ToDto(this Author model)
        {
            return new AuthorDto
            {                
                Id = model.Id,
                BirthDay = model.BirthDate,
                FullName = model.FirstName + " " + model.LastName,
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
            var firstName = model.FullName.Split(' ')[0];
            var lastName = model.FullName.Split(' ')[1];

            return new Author
            {
                Id = model.Id,
                BirthDate = model.BirthDay,
                FirstName = firstName,
                LastName = lastName,
                Gender = model.Gender
            };
        }
    }
}
