using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{ /// <summary>
  /// Book Copy Entity 
  /// </summary>
    [Table("bookcopy")]
    public class BookCopy : BaseAuditableEntity
    {
        public BookCopy()
        {
            
        }

        public BookCopy(string isbn, int copynum) 
        { 
            ISBN = isbn;
            CopyNum = copynum;        
        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int CopyNum { get; set; }
        public BookFormat Format { get; set; } 
        public BookCopyStatus Status { get; set; }
        public string ISBN { get; set; }
        public bool IsReferenceOnly { get; set; }
        public bool IsAvailable { get; set; }        
        public Book Book { get; set; }
        public Rack Rack { get; set; }

        //navigation properties
        public ICollection<Loan> Loans => new List<Loan>();
        public ICollection<Reservation> Reservations => new List<Reservation>();

    }
}
