using StudentService.Domain.Entities;

namespace StudentService.Application.Models.DTOs
{
    /// <summary>
    /// Represents the <see cref="CourseOffering"/> entity
    /// </summary>
    public class CourseOfferingDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
        public string QualificationTitle { get; set; }
        public int QualificationLevel { get; set; }
        public string CourseName { get; set; }
    }
}
