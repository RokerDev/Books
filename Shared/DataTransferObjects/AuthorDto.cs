namespace Shared.DataTransferObjects
{
    public record AuthorDto
    {
        public int Id { get; init; }
        public string? FullName { get; init; }

        public DateTime BirthDay { get; init; }

        public bool Gender { get; init; }

    }
}
