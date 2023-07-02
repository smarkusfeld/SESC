using LibraryService.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{
    [Table("author")]
    public class Author : BaseAuditableEntity
    {
        public override object Key => Id;
        public Author() { }
        public Author(string lastName)
        {
            LastName = lastName.Trim();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; } 
        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => string.Concat(FirstName, MiddleName, LastName);
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
