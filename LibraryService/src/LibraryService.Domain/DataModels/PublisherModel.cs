
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryService.Domain.Common;
using LibraryService.Domain.Entities.BookAggregate;

namespace LibraryService.Domain.DataModels
{
    [Table("publisher")]
    public class PublisherModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookPublisherModel> BookPublishers { get; set; }
    }


}
