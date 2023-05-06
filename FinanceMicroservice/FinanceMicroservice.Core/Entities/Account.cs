using FinanceMicroservice.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceMicroservice.Domain.Entities
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
