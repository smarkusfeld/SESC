using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.DataModels;
using LibraryService.Domain.ValueObjects;

namespace LibraryService.Domain.Entities
{
    public class BookCopy : BaseAuditableEntity
    {
        public BookCopy(string isbn, int copyNum)
        {
            IsAvailable = true;
            ISBN = isbn;
            Status = BookCopyStatus.Available;
            CopyNum = copyNum;
        }
        
        public override object Key => Id;
        public int Id { get; private set; }
        public int CopyNum { get; set; }
        public BookFormat Format { get; set; } 
        public BookCopyStatus Status { get; set; }
        public string ISBN { get; set; }
        public bool IsReferenceOnly { get; set; }
        public bool IsAvailable { get; set; }        
        public BookModel Book { get; set; } = null!;
        public Rack? Rack { get; set; }

        //backing fields for collections
        private readonly List<Loan> _loans = new();
        private readonly List<Reservation> _reservations = new();
        public ICollection<Loan> Loans => _loans;       
        public ICollection<Reservation> Reservations  => _reservations;

    }
}
