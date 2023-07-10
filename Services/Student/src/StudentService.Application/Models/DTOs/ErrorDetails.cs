﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class ErrorDetail
    {
        public bool hasErrors => Details.Any();
        public ErrorDetail()
        {
        }
        public ErrorDetail(string errorMessage, List<string> errorDetails) 
        { 
            Message = errorMessage;
            Details = errorDetails;

        }
        
        public string Message { get; set; } = string.Empty;
        public List<string> Details { get; set; } = new List<string>();
        
        
    }
}
