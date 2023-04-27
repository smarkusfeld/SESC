﻿using FinanceMicroservice.Domain.Interfaces;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceMicroservice.Domain.Entities
{
    [Table("invoice")]
    public class Invoice : IEntity
    {


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Invoice Date created is required")]
        public DateTime InvoiceDate { get; set; }
        public decimal total { get; set; }
        public decimal balance { get; set; }

        [Required(ErrorMessage = "Invoice Type is required")] 
        public string Type { get; set; }

        [Required(ErrorMessage = "Invoice Status is required")]
        public string Status { get; set; }

        public Account Account { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }

    

}
