using FinanceMicroservice.Domain.Interfaces;

namespace FinanceMicroservice.Domain.Entities
{
    public class Payment : IEntity
    {


        public DateTime PaymentDate { get; set; }
        public string Status { get; private set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public Invoice Invoice { get; set; }

    }
}
