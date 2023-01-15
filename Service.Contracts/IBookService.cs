using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        BookDto GetBook(int id, bool trackChanges);
        BookDto CreateBook(BookForCreationDto book);
        void DeleteBook(int id, bool trackChanges);
        void UpdateBook(int id, BookForUpdateDto book, bool trackChanges);
    }
}
