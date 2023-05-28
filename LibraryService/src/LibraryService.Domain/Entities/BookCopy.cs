using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("bookcopy")]
    public class BookCopy : IEntity
    {
        
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public ICollection<Loan> Loans { get; set; } 
    }
}
