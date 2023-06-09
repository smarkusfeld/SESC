using LibraryService.Domain.Common;
using LibraryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    [Table("book")]
    public class BookModel : BaseModel
    {
        [Key]
        public string ISBN { get; set; }
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookNum { get; set; }
        
        public string Title { get; set; }     
        
        public int Year { get; set; }
        
        public BookDetail Detail { get; set; }
        public BookClassification Classification { get; set; }
        public BookIdentifier Identifier { get; set; }
        public ICollection<BookSubjectModel> BookSubjects { get; set; }
        public ICollection<BookPublisherModel> BookPublishers { get; set;  }        
        public ICollection<BookAuthorModel> BookAuthors { get; set; }
        public ICollection<BookCopyModel> BookCopies { get; set; }
    }
}
