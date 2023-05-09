using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.DTOs
{
    public class PaymentDTO : IEntityDTO
    {
        public int ID { get; set; }
        public InvoiceDTO Invoice { get; set; }
        public AccountDTO Account { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public decimal Amount { get; set; }
    }
    
}
