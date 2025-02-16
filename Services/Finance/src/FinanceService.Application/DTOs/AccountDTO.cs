﻿using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.DTOs
{
    public class AccountDTO : IEntityDTO
    {
      
        public string StudentID { get; set; }
        public bool HasOutstandingBalance { get; set; }
       
        //public ICollection<InvoiceDTO>? Invoices { get; set; }
        // public ICollection<PaymentDTO>? Payments { get; set; }
    }
}
