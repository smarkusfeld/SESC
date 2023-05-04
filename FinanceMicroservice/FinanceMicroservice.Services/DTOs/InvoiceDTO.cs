using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceMicroservice.Application.DTOs
{
    public class InvoiceDTO : BaseDTO
    {
        [Required(ErrorMessage = "Valid ID required.")]
        public long ID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType Type { get; set; }

        public InvoiceStatus Status { get; set; }
        public decimal total { get; set; }

        public decimal balance { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
