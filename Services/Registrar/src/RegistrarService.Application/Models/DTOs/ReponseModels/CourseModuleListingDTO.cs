using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    public class CourseModuleListingDTO
    {
        public int CRN { get; set; }

        public int ModuleCode { get; set; }

        public string Name { get; set; }

        public int CourseLevelId { get; set; }

        public int AcademicYear { get; set; }
        public string AcademicTerm { get; set; }
    }
}
