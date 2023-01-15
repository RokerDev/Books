using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Service.Converters;
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

        public AuthorDto CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _repository.Author.CreateAuthor(authorEntity);
            _repository.Complete();
            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return authorToReturn;
        }

        public IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges)
        {
            var authors = _repository.Author.GetAllAuthors(trackChanges);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }

        public AuthorDto GetAuthor(int id, bool trackChanges)
        {
            var author = _repository.Author.GetAuthor(id, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(id);

            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }
        
    }   
}
