using Contracts;
using Service.Contracts;
using Service.Converters;
using Shared.DataTransferObjects;

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

        public IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges)
        {
                 var authors = _repository.Author.GetAllAuthors(trackChanges);
                var authorsDto = authors.Select(c => c.ToDto()).ToList();
                return authorsDto;
        }

        public AuthorDto GetAuthor(int id, bool trackChanges)
        {
            var author = _repository.Author.GetAuthor(id, trackChanges);
            if (author is null)
                throw new CompanyNotFoundException(id);

            var authorDto = author.ToDto(); 
            return authorDto;
        }
    }
}
