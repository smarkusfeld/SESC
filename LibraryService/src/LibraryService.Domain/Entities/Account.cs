using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    [Table("Accounts")]
    public class Account : IEntity
    {    
        public string StudentID { get; set; }

        public int Pin { get; set; } = 000000;

        public ICollection<Loan> Loans { get; set; }
    }
}
