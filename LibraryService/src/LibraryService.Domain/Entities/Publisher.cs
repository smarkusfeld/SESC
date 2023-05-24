using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Domain.Entities
{
    [Table("publisher")]
    public class Publisher : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }

    [Table("bookpublisher")]
    [PrimaryKey(nameof(Publisher), nameof(Book))]
    public class BookPublisher : IEntity
    {
        public Publisher Publisher { get; set; }
        public Book Book { get; set; }
    }
}
