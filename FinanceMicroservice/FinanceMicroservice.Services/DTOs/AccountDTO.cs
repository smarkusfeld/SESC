using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceMicroservice.Application.DTOs
{
    public class AccountDTO : BaseDTO
    {
        [Required(ErrorMessage = "Valid ID required.")]
        public long ID { get; set; }
    
        [Required (ErrorMessage = "StudentID required.")]
        public string StudentID { get; set; }

        [DefaultValue(false)]
        public bool HasOutstandingBalance { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Payment>? Payments { get; set; }

    }
}
