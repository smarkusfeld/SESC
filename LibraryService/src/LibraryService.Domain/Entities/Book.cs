using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("Books")]
    public class Book 
    {
        [Key]
        public int ISBN { get; set; }
        public string Title { get; set; }
       // public string Author { get; set; }
        public int Year { get; set; }    
        public int Copies { get; set; }
        public ICollection<TitleAuthor> TitleAuthors { get; set; }
        public ICollection<BookItem> BookItems { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate { get; set; }
    }
}
