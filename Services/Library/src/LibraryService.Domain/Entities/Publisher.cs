using LibraryService.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    ///  Publisher Entity
    /// </summary>
    [Table("publisher")]
    public class Publisher :BaseAuditableEntity
    {
        public override object Key { get => Id; }
        public Publisher() { }
        public Publisher(string name) 
        { 
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; } = new List<BookPublisher>();
    }
}
