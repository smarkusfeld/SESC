using LibraryService.Domain.Common;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    /// Library Account Entity
    /// </summary>
    public class Account : BaseAuditableEntity
    {
        public Account( string id) 
        { 
            AccountId = id;
        }
        public override object Key => AccountId;
        public string AccountId { get; private set; }
        public int AccountNum { get; private set; }
        public int Pin { get; set; } = 000000;
        public AccountType AccountType { get; set; } = null!;

        private readonly List<Loan> _loans = new();
        private readonly List<Reservation> _reservations = new();
        public ICollection<Loan> Loans => _loans;
        public ICollection<Reservation> Reservations => _reservations;

        public ICollection<Loan> OverdueLoans => _loans.FindAll(x => x.Status == Common.Enums.LoanStatus.Overdue);
        public ICollection<Loan> ActiveLoans => _loans.FindAll(x => x.IsComplete==false);


    }
}
