using System;
using System.Collections.Generic;

namespace Books.Models.Domains;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Rating { get; set; }

    public string Isbn { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; } = new List<BookAuthor>();
}
