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
    [Table("subject")]
    public class Subject : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<BookSubject> BookSubjects { get; set; }
    }

    [Table("booksubject")]
    [PrimaryKey(nameof(Subject), nameof(Book))]
    public class BookSubject : IEntity
    {        
        public Subject Subject { get; set; }
        public Book Book { get; set; }
    }
}
