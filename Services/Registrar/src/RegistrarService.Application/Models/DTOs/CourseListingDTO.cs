using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Models.DTOs
{
    /// <summary>
    /// Represents the <see cref="Course"/> for public course views and searches
    /// </summary>
    public class CourseListingDTO
    {
        public string CourseCode { get; set; }
        public string IsActive { get; set; }

        public string Name { get; set; }

        public string CourseType { get; set; }
        public DateTime ApplicationDeadline { get; set; }

        public DateTime EnrolmentDeadline { get; set; }
        public DateTime StartDate { get; set; }
        public bool EnrolmentOpen { get; set; }
        public bool ApplicationOpen { get; set; }
        public int Duration { get; set; }

        public int Credits { get; set; }

        public string CourseSchool { get; set; }

        public string CourseSubject { get; set; }

        public string CourseDegree { get; set; }

        public string ProgrammeCode { get; set; }
        public List<CourseLevelDTO> CourseLevels { get; set; }

    }
}
