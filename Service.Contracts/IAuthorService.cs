using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges);
    }
}
