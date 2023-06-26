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

        /// <summary>
        /// Constructor for Account Entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountType"></param>
        public Account( string id, AccountType accountType) 
        { 
            AccountId = id;
            AccountType = accountType;
        }           
      
        public string AccountId { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNum { get; private set; }

        public int Pin { get; set; } = 000000;
        public AccountType AccountType { get; set; }
        public ICollection<Loan> Loans { get; private set; } = new List<Loan>();
        public ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();


        

        //not mapped properties and methods
        public ICollection<Loan> OverdueLoans => Loans.ToList().FindAll(x => x.Status == Common.Enums.LoanStatus.Overdue);
        public ICollection<Loan> ActiveLoans => Loans.ToList().FindAll(x => x.IsComplete==false);

        public int OverdueLoanTotal => Loans.ToList().FindAll(x => x.Status == Common.Enums.LoanStatus.Overdue).Count();
        public int ActiveLoanTotal => Loans.ToList().FindAll(x => x.IsComplete == false).Count();


    }
}
