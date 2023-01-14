using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Column("BookId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Title is 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Rating is a required field.")]
        public decimal Rating { get; set; }

        [MaxLength(13, ErrorMessage = "Maximum length for the ISBN is 13 characters.")]
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "PublicationDate is a required field.")]
        public DateTime PublicationDate { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }


    }
}
