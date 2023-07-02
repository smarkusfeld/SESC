using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.DTOs
{

    public class NewInvoiceDTO
    {
        public string StudentId { get; set; }
        public string Reference { get; set; }        
        public DateTime DueDate { get; set; }
        public decimal Total { get; set; }
    }
}
