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
    public class BookPublisher : IEntity
    {
        public int BookID { get; set; }
        public int PublisherID { get; set; }

        [Required]
        [ForeignKey("PublisherID")]
        public Publisher Publisher { get; set; }
        [Required]
        [ForeignKey("BookID")]
        public Book Book { get; set; }

    }
}
