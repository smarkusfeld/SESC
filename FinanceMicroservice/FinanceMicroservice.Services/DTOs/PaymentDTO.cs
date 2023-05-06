using FinanceMicroservice.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceMicroservice.Application.DTOs
{
    public class PaymentDTO : BaseDTO
    {
        [Required(ErrorMessage = "Valid ID required.")]
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; private set; }

        public decimal Amount { get; set; }


    }
}
