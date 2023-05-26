using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
     [Table("bookidentifier")]

    public class BookIdentifier : IEntity
    {
        public string Value { get; set; }
        public int BookID { get; set; }
        public int IndentifierID { get; set; }

        [Required]
        [ForeignKey("IndentifierID")]
        public Identifier Identifier { get; set; }
        [Required]
        [ForeignKey("BookID")]
        public Book Book { get; set; }
    }
}
