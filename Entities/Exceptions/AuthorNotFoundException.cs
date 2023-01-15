public sealed class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException(int id)
    : base($"The Author with id: {id} doesn't exist in the database.")
    {
    }
}