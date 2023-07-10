using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class CourseDTO
    {
        public string CourseCode { get; set; }  
        public int Id { get; set; }
        public string IsActive { get; set; }

        public string Name { get; set; }

        public string CourseType { get; set; }

        public int Duration { get; set; }
        public int SubjectId { get; set; }
        public int SchoolId { get; set; }
        public int AwardId { get; set; } 
        public string CourseSchool { get; set; }

        public string CourseDegree { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
