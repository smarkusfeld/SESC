using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    [Table("account")]
    public class Account : IEntity
    {

        public string StudentID { get; set; }

        public bool HasOutstandingBalance { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
