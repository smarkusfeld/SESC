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

    public class BookIdentifier : BaseEntity
    {
        public string Value { get; set; }
        public int BookId { get; set; }
        public int IndentifierId { get; set; }

       
        public Identifier Identifier { get; set; }

        public Book Book { get; set; }
    }
}
