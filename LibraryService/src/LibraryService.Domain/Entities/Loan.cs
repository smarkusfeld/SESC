using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    [Table("Loans")]
    public class Loan : IEntity
    {
        public DateTime DateBorrowed { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime? DateReturned { get; set; } = null;
        public int AccountID { get; set; }

        public int BookCopyID { get; set; }
        public BookCopy BookCopy { get; set; }

        public Account Account { get; set; }
    }

   
}
