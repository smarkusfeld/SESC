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
    public class BookSubject : IEntity
    {
        public int BookID { get; set; }
        public int SubjectID { get; set; }

        [Required]
        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }

        [Required]
        [ForeignKey("BookID")]
        public Book Book { get; set; }

    }
}
