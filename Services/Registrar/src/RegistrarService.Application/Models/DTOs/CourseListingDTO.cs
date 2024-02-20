using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Models.DTOs
{
    /// <summary>
    /// Represents the <see cref="Course"/> for public course views and searches
    /// </summary>
    public class CourseListingDTO
    {
        public int Id { get; set; }
        public string IsActive { get; set; }

        public string Name { get; set; }

        public string CourseType { get; set; }

        public int Duration { get; set; }

        public string CourseSchool { get; set; }

        public string CourseDegree { get; set; }

        public List<CourseLevelDTO> CourseLevels { get; set; }

    }
}
