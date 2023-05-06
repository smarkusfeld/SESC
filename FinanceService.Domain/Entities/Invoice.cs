using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    public class Invoice : IEntity    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Reference { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public Account Account { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }

}
