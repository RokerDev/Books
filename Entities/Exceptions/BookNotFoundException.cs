namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id)
         :   base($"The Book with id: {id} doesn't exist in the database.")
        { 
            
        }
    }
}
