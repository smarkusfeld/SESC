using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Domain.Entities
{
    [Table("Payments")]
    public class Payment : IEntity
    {
        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string PaymentReference { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public PaymentStatus Status { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Amount { get; set; }

        public int AccountID { get; set; }

        public int InvoiceID { get; set; }

        [Required]
        [ForeignKey("AccountID")]
        public Account Account { get; set; }

        [Required]
        [ForeignKey("InvoiceID")]        
        public Invoice Invoice { get; set; }

    }
    public enum PaymentStatus
    {
        Recieved,
        Processed,
        Cancelled,
        Declined
    }
    public enum PaymentMethod
    {
        CashCheck,
        BACS,
        DebitCredit,
        Other
    }
}
