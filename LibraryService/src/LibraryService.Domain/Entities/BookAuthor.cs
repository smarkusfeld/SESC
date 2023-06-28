using LibraryService.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace LibraryService.Domain.Entities
{
    [Table("bookauthor")]
    public class BookAuthor 
    {
        public BookAuthor() { }
        internal byte Order { get; set; }
        public string ISBN { get; private set; }
        public int AuthorId { get; private set; }
        public string AuthorName { get; private set; }
        public Book? Book { get; set; } 
        public Author Author { get; private set; }       
        public BookAuthor(int num, string isbn, int authorId, string name)
        {
            Order = (byte)num;
            ISBN = isbn;
            AuthorId = authorId;
            AuthorName = name;
        }
    }
}
