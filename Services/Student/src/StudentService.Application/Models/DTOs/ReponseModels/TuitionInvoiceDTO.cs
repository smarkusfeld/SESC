using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.ReponseModels
{
    public class TuitionInvoiceDTO
    {
        public string StudentID { get; set; }
        public string Reference { get; set; }
        public float Amount { get; set; }

    }
}
