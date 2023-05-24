using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("author")]
    public class Author : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookAuthor>BookAuthors { get; set; }
    }

    [Table("bookauthor")]
    [PrimaryKey(nameof(Author), nameof(Book))]
    public class BookAuthor : IEntity
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
