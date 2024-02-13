using StudentService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.InputModels
{
    public class CourseRegistrationDTO
    {
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public int StartYear { get; set; }

    }
}
