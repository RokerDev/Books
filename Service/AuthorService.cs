using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public AuthorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges)
        {
            try
            {
                var authors = _repository.Author.GetAllAuthors(trackChanges);
                var authorsDto = authors.Select(c =>
                new AuthorDto(c.Id, string.Join(' ', c.FirstName, c.LastName), c.BirthDate, c.Gender)).ToList();
                return authorsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllAuthors)} service method { ex }");
                throw;
            }

        }
    }
}
