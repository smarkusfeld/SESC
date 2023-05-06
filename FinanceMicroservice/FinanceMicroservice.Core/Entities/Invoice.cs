using FinanceMicroservice.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceMicroservice.Domain.Entities
{
    [Table("invoice")]
    public class Invoice : IEntity
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Reference { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public Account Account { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }



}
