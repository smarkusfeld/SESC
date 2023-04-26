using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceMicroservice.Core.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        public string StudentID { get; set; }

        public bool HasOutstandingBalance { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
