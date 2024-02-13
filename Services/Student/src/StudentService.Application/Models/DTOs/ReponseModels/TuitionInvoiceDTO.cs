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
   
        public float Amount { get; set; }

        public int SessionId { get; set; }
        
        public int CourseLevelId { get; set; }

        public string CourseLevelName { get; set; }

        public string CourseCode { get; set; }

    }
}
