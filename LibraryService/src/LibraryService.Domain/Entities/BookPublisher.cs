using LibraryService.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{
    [Table("bookpublisher")]
    public class BookPublisher : BaseEntity
    {
        internal byte Order { get; set; }
        public string ISBN { get; private set; }
        public int PublisherId { get; private set; }
        public string PublisherName { get; private set; }
        public Book? Book { get; set; } 
        public Publisher Publisher { get; private set; } 
        public BookPublisher(int num, string isbn, int publisherId, string name)
        {
            byte order = (byte)num;
            Order = order;
            ISBN = isbn;
            PublisherId = publisherId;
           PublisherName = name;
        }

    }
}
