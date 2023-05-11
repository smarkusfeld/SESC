﻿using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.DTOs
{
    public class InvoiceDTO : IEntityDTO
    {

        public string Reference { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public AccountDTO Account { get; set; }
        public ICollection<PaymentDTO>? Payments { get; set; }
    }

   
}
