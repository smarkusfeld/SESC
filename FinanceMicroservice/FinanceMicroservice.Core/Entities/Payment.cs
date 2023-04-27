using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceMicroservice.Domain.Interfaces;

namespace FinanceMicroservice.Domain.Entities
{
    public class Payment : IEntity
    {

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Payment Date created is required")]
        public DateTime PaymentDate { get; set; }
        public string Status { get; private set; }
        public decimal amount { get; set; }
        public Account Account { get; set; }
        public Invoice Invoice{ get; set; }

    }
}
