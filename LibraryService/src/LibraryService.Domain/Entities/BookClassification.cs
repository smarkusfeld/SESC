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
    public class BookClassification : BaseEntity
    {
        public string Value { get; set; }
        public int BookId { get; set; }
        public int ClassificationID { get; set; }

        public Classification Classification { get; set; }

        public Book Book { get; set; }
    }
}
