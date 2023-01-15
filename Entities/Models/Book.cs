using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Title is 50 characters.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Description is a required field.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Rating is a required field.")]
    public decimal Rating { get; set; }

    [Required(ErrorMessage = "Isbn is a required field.")]
    [MaxLength(13, ErrorMessage = "Maximum length for the Isbn is 13 characters.")]
    public string Isbn { get; set; } = null!;

    [Required(ErrorMessage = "PublicationDate is a required field.")]
    public DateTime PublicationDate { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; } = new List<BookAuthor>();
}
