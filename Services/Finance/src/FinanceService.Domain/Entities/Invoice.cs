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

        [Required]
        
        public DateTime InvoiceDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]        
        [Column(TypeName = "varchar(20)")]
        public string Reference { get; set; }


        // public decimal Total { get; set; }

        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Balance { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public InvoiceType Type { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public InvoiceStatus Status { get; set; }

        public string StudentID { get; set; }
        public int AccountID { get; set; }

        [Required]
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
    public enum InvoiceStatus
    {
        Outstanding,
        Paid,
        Cancelled
    }
    public enum InvoiceType
    {
        Tutition,
        Library,
        Fee
    }
}
