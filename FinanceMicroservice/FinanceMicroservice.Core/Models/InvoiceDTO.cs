using System.ComponentModel.DataAnnotations;

namespace FinanceMicroservice.Core.Models
{
    public class InvoiceDTO
    {
        public long ID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType Type { get; set; }
        
        public InvoiceStatus Status { get; set; }
        public decimal total { get; set; }

        public decimal balance { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
