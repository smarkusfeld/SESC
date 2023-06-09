using LibraryService.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    [Table("bookpublisher")]
    public class BookPublisherModel
    {
        public byte Order { get; set; }
        public string ISBN { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public BookModel Book { get; set; } = null!;
        public PublisherModel Publisher { get; set; } = null!;
    }
}
