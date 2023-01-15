using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public partial class Author
{
    [Column("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Author Firstname is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Author LastName is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Author BirthDate is a required field.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Author Gender is a required field.")]
    public bool Gender { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; } = new List<BookAuthor>();
}
