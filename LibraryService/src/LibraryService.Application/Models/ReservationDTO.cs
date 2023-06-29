using LibraryService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class ReservationDTO : BaseAuditableModel
    {
        public int Id { get; private set; }
        public DateTime RequestDate { get; set; }
        public DateTime NeededBy { get; set; }
        public ReservationStatus Status { get; set; }
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public string AccountId { get; set; }
        public int BookCopyId { get; set; }
    }
}
