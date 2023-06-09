using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    public class Reservation : BaseModel
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? NeededDate { get; set; }
        public ReservationStatus Status { get; set; }
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public string AccountId { get; set; }
        public int BookCopyId { get; set; }
        public AccountModel Account { get; set; }
        public BookCopyModel BookCopy { get; set; }
    }
}
