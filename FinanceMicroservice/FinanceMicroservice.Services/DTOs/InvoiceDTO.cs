using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceMicroservice.Application.DTOs
{
    public class InvoiceDTO : BaseDTO
    {
        [Required(ErrorMessage = "Valid ID required.")]
        public int ID { get; set; }

        public int AccountID { get; set; }

        public string Reference { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public InvoiceType Type { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
