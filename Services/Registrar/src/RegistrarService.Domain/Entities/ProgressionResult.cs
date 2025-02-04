using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using RegistrarService.Domain.Interfaces;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    ///  Result Entity
    /// </summary>
    public class ProgressionResult : BaseAuditableEntity, IAggregateRoot
    {
        private ProgressionResult() { }

        internal ProgressionResult(int studentId, int courseLevel, ProgressDecision progressDecision, string progressNotes)
        {
            StudentId = studentId;
            CourseLevelId = courseLevel;
            ProgressDecision = progressDecision;
            ProgressDate = DateTime.Now;
            ProgressNotes = progressNotes ?? string.Empty;
        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        
        public ProgressDecision ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string? ProgressNotes { get; set; } 
        public int StudentId { get; set; }
        public int CourseLevelId { get; set; }

        //navigation properties
     
        public Student Student { get; set; }
        public CourseLevel CourseLevel { get; set; }

        //[NotMapped]
        //public AcademicYear AcademicYear => CourseLevel.AcademicYear;

        //[NotMapped]
        //public string CourseLevelName => CourseLevel.Name;

        //[NotMapped]
        //public string CourseCode => CourseLevel.Course.CourseCode;                         
    }
}
