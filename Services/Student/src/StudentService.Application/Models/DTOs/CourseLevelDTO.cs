using StudentService.Domain.Entities;

namespace StudentService.Application.Models.DTOs
{
    /// <summary>
    /// Represents the <see cref="CourseLevel"/> entity
    /// </summary>
    public class CourseLevelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
        public int QualificationLevel { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public float TuitionFee { get; set; }
        public int CourseId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
