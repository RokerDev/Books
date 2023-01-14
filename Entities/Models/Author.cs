using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 50 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Birth Date is a required field.")]
        public DateTime BirthDate { get; set; }

        public ICollection<Book>? Employees { get; set; }

    }
}
