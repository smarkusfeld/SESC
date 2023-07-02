

using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Models 
{
    public class AccountDTO : BaseAuditableModel
    {
        
        public string AccountId { get;  set; }
        public int AccountNum { get; }
        public int Pin { get; set; }
        public AccountType AccountType { get; set; }

        public int OverdueLoanTotal { get; private set; }
        public int ActiveLoanTotal { get; private set; } 
    }
}
