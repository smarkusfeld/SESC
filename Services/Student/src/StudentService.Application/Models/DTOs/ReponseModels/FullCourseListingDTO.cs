using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.ReponseModels
{
    public class FullCourseListingDTO
    {
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
        public string CourseType { get; set; }

        public int Duration { get; set; }
        public string CourseSchool { get; set; }
        public string CourseSubject { get; set; }
        public string CourseDegree { get; set; }

        public List<string> CourseLevels { get; set; }   
    }
}
