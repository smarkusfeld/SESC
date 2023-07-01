using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class ErrorDetail
    {
        public ErrorDetail(string errorMessage, List<string> errorDetails) 
        { 
            Message = errorMessage;
            Details = errorDetails;

        }
        public ErrorDetail(string errorMessage)
        {
            Message = errorMessage;

        }
        public string Message { get; set; }
        public List<string> Details { get; set; } = new List<string>();
        
        
    }
}
