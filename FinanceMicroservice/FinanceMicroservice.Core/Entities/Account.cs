using FinanceMicroservice.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceMicroservice.Domain.Entities
{
    [Table("account")]
    public class Account : IEntity
    {
       
        [Required(ErrorMessage = "Student ID is required")]
        public string StudentID { get; set; }

        public bool HasOutstandingBalance { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
