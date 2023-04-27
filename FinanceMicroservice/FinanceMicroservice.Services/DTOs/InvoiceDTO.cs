using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;

namespace FinanceMicroservice.Application.DTOs
{
    public class InvoiceDTO : BaseDTO
    {
        public DateTime InvoiceDate { get; set; }
        public InvoiceType Type { get; set; }

        public InvoiceStatus Status { get; set; }
        public decimal total { get; set; }

        public decimal balance { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
