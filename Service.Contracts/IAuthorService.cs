using Entities.Models;

namespace Service.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
    }
}
