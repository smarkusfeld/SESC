using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentService.Domain.Common;
using System.Reflection;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Level Session
    /// Part of <seealso cref="Course"/> Aggregate Entity 
    /// </summary>
    public class Session : BaseAuditableEntity
    {
        private Session() { }

        /// <summary>
        /// Internal constructor used by <seealso cref="CourseLevel"/> to create Sessions 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="courseModules"></param>
        internal Session(AcademicYear year, AcademicTerm term, List<CourseModule> courseModules)
        {
            AcademicYear = year;
            AcademicTerm = term;
            IsActive = true;
            CreateSessionModules(courseModules);
        }
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CourseLevelId { get; set; }

        public int AcademicTermId { get; set; }

        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public AcademicTerm AcademicTerm { get; set; }
        public bool EnrolmentOpen { get; set; }
        public bool IsActive { get; set; }  
        public CourseLevel CourseLevel { get; private set; }
        public ICollection<SessionModule> SessionModules { get; private set; } 

        public void UpdateSessionModules(List<CourseModule> courseModules)
        {
            CreateSessionModules(courseModules);

        }
        
        private void CreateSessionModules(List<CourseModule> courseModules)
        {
            List<SessionModule> sessionModules = new();
            foreach (var courseModule in courseModules)
            {
                sessionModules.Add(new(courseModule.Id));
            }
            SessionModules = sessionModules;            
        }
        
    }
}
