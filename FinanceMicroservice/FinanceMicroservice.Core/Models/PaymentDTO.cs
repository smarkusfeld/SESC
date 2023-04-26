using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Core.Models
{
    public class PaymentDTO
    {
        public long ID { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Payment Date created is required")]
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; private set; }

        public decimal amount { get; set; }
    }
}
