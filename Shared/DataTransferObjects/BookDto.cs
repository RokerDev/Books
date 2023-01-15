namespace Shared.DataTransferObjects
{
    public record BookDto
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public decimal Rating { get; init; }
        public string? Isbn { get; init; }
        public DateTime PublicationDate { get; init; }

    }
}
