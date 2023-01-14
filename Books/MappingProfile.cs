using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Books
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>().ForMember(c => c.FullName,
                opt => opt.MapFrom(x => string.Join(" ", x.FirstName, x.LastName)));
        }
    }
}
