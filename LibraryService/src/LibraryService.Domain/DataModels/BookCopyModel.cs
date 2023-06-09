using LibraryService.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibraryService.Domain.ValueObjects;
using LibraryService.Domain.Common.Enums;

namespace LibraryService.Domain.DataModels
{
    [Table("book")]
    public class BookCopyModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CopyNum { get; set; }
        public BookFormat Format { get; set; }
        public BookCopyStatus Status { get; set; }
        public string ISBN { get; set; }
        public bool IsReferenceOnly { get; set; }
        public bool IsAvailable { get; set; }
        public BookModel? Book { get; set; }

        public Rack? Rack { get; set; }
        public ICollection<LoanModel>? Loans { get; set; }
        public ICollection<ReservationModel>? Reservations { get; set; }

    }
}
