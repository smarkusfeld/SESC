using StudentService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.InputModels
{
    public class NewCourseDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string CourseType { get; set; }
        public int Duration { get; set; }
        public int SchoolId { get; set; }
        public string CourseSchool { get; set; }
        public int SubjectId { get; set; }
        public string CourseSubject { get; set; }
        public int AwardId { get; set; }
        public string CourseAward { get; set; }

      
        public List<string> ContainedCourseAwards { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
