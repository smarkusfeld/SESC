using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    /// <summary>
    /// Data Transfer Object for student results
    /// <br> View only to protect data models</br>
    /// </summary>
    public class StudentProgressionDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }        

        public string Status { get; set; }

        public IEnumerable<ProgressionDTO> Results { get; set; } = new List<ProgressionDTO>();
    }

    public class ProgressionDTO
    {
        public string Id { get; set; }
        public int StudentId { get; set; }
        public int CourseLevelId { get; set; }
        public string AcademicYear { get; set; }
        public string CourseCode { get; set; }

        public string CourseLevelName { get; set; }
        public string ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string? ProgressNotes { get; set; }
    }

}
