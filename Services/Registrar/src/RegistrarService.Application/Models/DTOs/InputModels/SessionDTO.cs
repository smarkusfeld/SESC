using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public int CourseLevelId { get; set; }

        public int AcademicTermId { get; set; }

        public int AcademicYearId { get; set; }
        public AcademicYearDTO AcademicYear { get; set; }
        public AcademicTermDTO AcademicTerm { get; set; }
        public bool EnrolmentOpen { get; set; }
        public bool IsActive { get; set; }
    }
}
