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
        public Invoice Invoice { get; set; }
        public Account Account { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public decimal Amount { get; set; }
    }
    
}
