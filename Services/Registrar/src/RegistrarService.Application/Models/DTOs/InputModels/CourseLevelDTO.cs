using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Models.DTOs.InputModels
{
    /// <summary>
    /// Represents the <see cref="Session"/> entity
    /// </summary>
    public class CourseLevelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
        public int QualificationLevel { get; set; }
        public float TuitionFee { get; set; }
        public int CourseId { get; set; }
        
        public List<CourseModuleDTO> CourseModules { get; set; }
        public List<SessionDTO> Sessions { get; set; }
    }
}
