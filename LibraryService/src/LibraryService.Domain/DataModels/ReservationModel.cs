using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DataModels
{
    [Table("reservation")]
    public class ReservationModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
