using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges);
        AuthorDto GetAuthor(int id, bool trackChanges);
        AuthorDto CreateAuthor(AuthorForCreationDto author);
    }
}
