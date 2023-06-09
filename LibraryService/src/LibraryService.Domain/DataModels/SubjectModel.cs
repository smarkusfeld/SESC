
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryService.Domain.Common;

namespace LibraryService.Domain.DataModels
{
    [Table("subject")]
    public class SubjectModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookSubjectModel> BookSubjects { get; set; }

    }


}
