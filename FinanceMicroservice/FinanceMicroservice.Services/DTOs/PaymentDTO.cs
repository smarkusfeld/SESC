using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;


namespace FinanceMicroservice.Application.DTOs
{
    public class PaymentDTO : BaseDTO
    {
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; private set; }

        public decimal amount { get; set; }
    }
}
