using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public IEnumerable<Loan> OverdueLoans => Loans != null ? Loans.Where(x => x.Status == LoanStatus.Overdue) : Enumerable.Empty<Loan>();
   

        [NotMapped]
        public IEnumerable<Loan> ActiveLoans => Loans!= null ? Loans.Where(x => x.IsComplete==false) :  Enumerable.Empty<Loan>();
        
       public int OverdueLoanTotal => OverdueLoans.Count();
      

        public int ActiveLoanTotal => ActiveLoans.Count();


    }
}
