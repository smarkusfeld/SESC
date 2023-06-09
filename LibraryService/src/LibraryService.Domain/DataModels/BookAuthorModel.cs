using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    [Table("bookauthor")]
    public class BookAuthorModel
    {
        public byte Order { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public BookModel Book { get; set; } = null!;
        public AuthorModel Author { get; set; } = null!;
    }
}
