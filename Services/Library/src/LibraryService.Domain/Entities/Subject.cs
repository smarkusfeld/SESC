using LibraryService.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{
    [Table("subject")]
    public class Subject : BaseAuditableEntity
    {
        public Subject() { }
        public override object Key { get => Id; }
        public Subject(string name) 
        { 
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookSubject> BookSubjects { get; set; } = null!;

    }
}
