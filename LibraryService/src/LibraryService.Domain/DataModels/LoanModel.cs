using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Entities.LoanAggregate;
using LibraryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    [Table("loan")]
    public class LoanModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateReturned { get; set; } = null;
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public string AccountId { get; set; }
        public int BookCopyId { get; set; }
        public LoanStatus Status { get; set; }
        public AccountModel Account { get; set; }
        public BookCopyModel BookCopy { get; set; }

    }
}
