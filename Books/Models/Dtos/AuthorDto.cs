namespace Books.Models.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }
    }
}
