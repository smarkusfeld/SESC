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
    public class BookAuthor 
    {
        internal byte Order { get; set; }
        public string ISBN { get; private set; }
        public int AuthorId { get; private set; }
        public string AuthorName { get; private set; }
        public Book Book { get; private set; } = null!;
        public Author Author { get; private set; } = null!;        
        public BookAuthor(int num, string isbn, int authorId, string name)
        {
            byte order = (byte)num;
            Order = order;
            ISBN = isbn;
            AuthorId = authorId;
            AuthorName = name;
        }
    }
}
