using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs
{
    public class EnrolmentDTO
    {
        public int Id { get; set; }

        public DateTime EnrolDate { get; set; }
        public int CourseLevelId { get; set; }
        public int StudentId { get; set; }
        public int Tutition { get; set; }
        public string StudentName { get; set; }

        public string CourseOfferingName { get; set; }

        public string CourseName { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
