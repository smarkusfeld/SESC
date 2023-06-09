using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    [Table("booksubject")]
    public class BookSubjectModel 
    {

        public string ISBN { get; set; }
        public int SubjectId { get; set; }  
        public string SubjectName { get; set; }
        public BookModel Book { get; set; } = null!;
        public SubjectModel Subject { get; set; } = null!;
    }
}
