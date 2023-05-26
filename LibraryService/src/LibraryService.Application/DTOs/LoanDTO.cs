using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    public class LoanDTO
    {
        public new int ID { get; set; } 
        public int ISBN { get; set; }
        public string StudentID { get; set; }

        public string BookTitle { get; set; }
        public int AccountID { get; set; }
        public int BookCopyID { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; } = null;


    }
}
