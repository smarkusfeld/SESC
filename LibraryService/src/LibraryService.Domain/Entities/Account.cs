using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    /// Library Account Entity
    /// </summary>
    [Table("account")]
    public class Account : BaseAuditableEntity, IAggregateRoot
    {
        
        public override object Key => AccountId;          
      
        public string AccountId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNum { get; private set; }

        public int Pin { get; set; } = 000000;
        public AccountType AccountType { get; set; }
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();
        public ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();




        //not mapped properties and methods
        [NotMapped]
        public ICollection<Loan> OverdueLoans => Loans.ToList().FindAll(x => x.Status == Common.Enums.LoanStatus.Overdue);

        [NotMapped]
        public ICollection<Loan> ActiveLoans => Loans.ToList().FindAll(x => x.IsComplete==false);
       
        public int OverdueLoanTotal => Loans.ToList().FindAll(x => x.Status == Common.Enums.LoanStatus.Overdue).Count();
        public int ActiveLoanTotal => Loans.ToList().FindAll(x => x.IsComplete == false).Count();


    }
}
