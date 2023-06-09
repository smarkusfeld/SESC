using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common;
using LibraryService.Domain.DataModels;

namespace LibraryService.Domain.Entities
{

    public class BookPublisher 
    {
        internal byte Order { get; set; }
        public string ISBN { get; private set; }
        public int PublisherId { get; private set; }
        public string PublisherName { get; private set; }
        public Book Book { get; private set; } = null!;
        public Publisher Publisher { get; private set; } = null!;
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
