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
    [Table("loan")]
    public class Loan : BaseEntity
    {
        
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateReturned { get; set; } = null;
        public int AccountId { get; set; }
        public int BookCopyId { get; set; }
        public string ISBN { get; set; }
        public BookCopy BookCopy { get; set; }
        public Account Account { get; set; }
    }

   
}
