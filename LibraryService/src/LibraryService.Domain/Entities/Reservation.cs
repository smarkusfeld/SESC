using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    /// Reservation Entity
    /// </summary>
    [Table("reservation")]
    public class Reservation : BaseAuditableEntity
    {
        public override object Key => Id;
        public Reservation() { }
        public Reservation(DateTime neededBy, string bookISBN, string bookTitle, string accountId, int bookCopyId)
        {
            RequestDate = DateTime.Now;
            NeededBy = neededBy;
            BookISBN = bookISBN;
            BookTitle = bookTitle;
            AccountId = accountId;
            BookCopyId = bookCopyId;

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime RequestDate { get; set; }
        public DateTime NeededBy { get; set; }
        public ReservationStatus Status { get; set; }
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public string AccountId { get; set; }
        public int BookCopyId { get; set; }
        public Account Account { get; set; } = null!;
        public BookCopy BookCopy { get; set; } = null!;
    }
}
