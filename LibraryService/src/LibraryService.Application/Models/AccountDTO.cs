

using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Models
{
    public class AccountDTO
    {
        
        public string AccountId { get;  set; }
        public int AccountNum { get; }
        public int Pin { get; set; }
        public AccountType AccountType { get; set; }

        

    }
}
