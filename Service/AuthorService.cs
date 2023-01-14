using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public AuthorService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Author> GetAllAuthors(bool trackChanges)
        {
            try
            {
                var authors =
                _repository.Author.GetAllAuthors(trackChanges);
                return authors;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllAuthors)} service method { ex }");
                throw;
            }

        }
    }
}
