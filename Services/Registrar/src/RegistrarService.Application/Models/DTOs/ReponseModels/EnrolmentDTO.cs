using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    public class EnrolmentDTO
    {
        public DateTime EnrolDate { get; set; }
        public int StudentId { get; set; }
        public int Tutition { get; set; }
        public string AcademicYear { get; set; }
        public string AcademicTerm { get; set; }
        public string CourseLevelName { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public List<string> SessionModules { get; set; }
    }
}
