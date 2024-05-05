using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    /// <summary>
    /// Represents the <see cref="CourseLevel"/> entity for public views and searches
    /// <br> View only to protect data models</br>
    /// </summary>
    public class CourseLevelListing
    {
        public int CourseLevelId { get; private set; }
        public string Name { get; private set; }
        public int Credits { get; private set; }
        public int QualificationLevel { get; private set; }
        public float TuitionFee { get; private set; }
        public string CourseCode { get; private set; }

        public string AcademicYear { get; private set; }
        public List<string> CourseModules { get; private set; }
    }
}
