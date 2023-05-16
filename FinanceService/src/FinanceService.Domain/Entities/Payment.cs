using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    [Table("Payments")]
    public class Payment : IEntity
    {
       
        public DateTime PaymentDate { get; set; }
        public string PaymentReference { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
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
