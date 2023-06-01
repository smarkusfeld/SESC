using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("bookpublisher")]
    public class BookPublisher : BaseEntity
    {
        public int BookId { get; set; }
        public int PublisherId { get; set; }

        
        public Publisher Publisher { get; set; }
       
        public Book Book { get; set; }

    }
}
