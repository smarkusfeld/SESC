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
        public bool HasOutstandingBalance { get; set; }

        public ICollection<Invoice> Invoices { get; } = new List <Invoice>();
        public ICollection<Payment> Payments { get; } = new List<Payment>();
    }
}
