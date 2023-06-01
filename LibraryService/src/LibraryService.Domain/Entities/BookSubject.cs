using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("booksubject")]
    public class BookSubject : BaseEntity
    {
        
       
        public int BookId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
                
        public Book Book { get; set; }

        

    }
}
