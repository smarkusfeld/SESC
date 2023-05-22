using FinanceService.Application.Mapper;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.DTOs
{
    public class InvoiceDTO : IEntityDTO
    {
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        public string StudentID { get; set; }

        [Required(ErrorMessage = "Invoice Reference is required")]
        public string Reference { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Invoice Due Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        
        public InvoiceType Type { get; set; }
        public InvoiceStatus Status { get; set; }

        [Required(ErrorMessage = "Invoice Total is Required")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }


        //public ICollection<PaymentDTO>? Payments { get;private set; }
        //public AccountDTO? Account { get; set; }
    }

   
}
