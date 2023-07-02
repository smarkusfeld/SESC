using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string IsActive { get; set; }

        public string Name { get; set; }

        public string CourseType { get; set; }

        public int Duration { get; set; }

        public int SchoolId { get; set; }
        public int DegreeId { get; set; }
        public string CourseSchool { get; set; }

        public string CourseDegree { get; set; }

    }
}
