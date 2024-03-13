using RegistrarService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{   
    
    /// <summary>
     /// Data Transfer Object for student
     /// <br> View only to protect data models</br>
     /// </summary>
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public string StudentEmail { get; set; }

        public StudentStatus Status { get; private set; }

        public int CourseCode { get; set; }

        public string CourseName { get; set; }
    }
}
