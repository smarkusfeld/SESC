using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{

    [Table("bookauthor")]

    public class BookAuthor : IEntity
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public Book Book { get; set; }     
        public Author Author { get; set; }
    }
}
