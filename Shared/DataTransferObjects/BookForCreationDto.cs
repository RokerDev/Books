namespace Shared.DataTransferObjects
{
    public record BookForCreationDto(string Title, string Description, decimal Rating, string Isbn, DateTime PublicationDate);

}
