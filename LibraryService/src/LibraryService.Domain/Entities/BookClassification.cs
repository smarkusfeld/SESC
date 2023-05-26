using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
     [Table("bookclassification")]
    public class BookClassification : IEntity
    {
        public string Value { get; set; }
        public int BookID { get; set; }
        public int ClassificationID { get; set; }

        [Required]
        [ForeignKey("ClassificationID")]
        public Classification Classification { get; set; }
        [Required]
        [ForeignKey("BookID")]
        public Book Book { get; set; }
    }
}
