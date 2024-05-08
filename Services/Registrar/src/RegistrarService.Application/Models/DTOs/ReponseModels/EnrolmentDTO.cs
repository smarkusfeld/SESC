using RegistrarService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    public class EnrolmentDTO
    {
        public int Id { get; private set; }
        public DateTime EnrolDate { get; set; }
        public int StudentId { get; set; }
        public int CourseLevelId { get; private set; }
        public string Status { get; private set; }
        public float Tutition { get; set; }
        public string AcademicYear { get; set; }
        public string AcademicTerm { get; set; }
        public string CourseLevelName { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
    }
}
