using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;

namespace FinanceMicroservice.Application.DTOs
{
    public class AccountDTO : BaseDTO
    {
        public string StudentID { get; set; }

        public bool HasOutstandingBalance { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Payment>? Payments { get; set; }

    }
}
