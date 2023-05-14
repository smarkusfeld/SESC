using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    [Table("Invoices")]
    public class Invoice : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Reference { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public Account Account { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
    public enum InvoiceStatus
    {
        Outstanding,
        Paid,
        Candelled
    }
    public enum InvoiceType
    {
        Tutition,
        Library
    }
}
