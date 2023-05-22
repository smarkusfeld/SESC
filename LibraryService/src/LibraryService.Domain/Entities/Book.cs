using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("Books")]
    public class Book : IEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }    
        public int Copies { get; set; }

        public ICollection<TitleAuthor> TitleAuthors { get; set; }
        public ICollection<BookItem> BookItems { get; set; }
    }
}
