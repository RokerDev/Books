using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        BookDto GetBook(int id, bool trackChanges);
        BookDto CreateBook(BookForCreationDto book);

    }
}
