using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.DTOs
{
    public class AccountDTO : IEntityDTO
    {
        public string StudentID { get; set; }
        public bool HasOutstandingBalance { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
