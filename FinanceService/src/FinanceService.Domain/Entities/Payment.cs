﻿using System;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
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
