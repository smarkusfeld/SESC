using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    public class Payment : IEntity
    {
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public Invoice Invoice { get; set; }

    }
    public enum PaymentStatus
    {
        Recieved,
        Processed,
        Cancelled,
        Declined
    }
    public enum PaymentMethod
    {
        CashCheck,
        BACS,
        DebitCredit,
        Other
    }
}
