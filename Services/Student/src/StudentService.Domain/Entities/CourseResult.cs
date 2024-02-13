using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Common.Enums.StudentService.Domain.Common.Enums;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Result Entity
    /// </summary>
    public class CourseResult : BaseAuditableEntity
    {
        private CourseResult() { }

        internal CourseResult(string studentId, int sessionId, ProgressDecision progressDecision, string progressNotes)
        {
            StudentId = studentId;
            SessionId = sessionId;
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
        public string StudentId { get; set; }
        public int SessionId { get; set; }
        public int TranscriptId { get; set; }

        //navigation properties
     
        public Session Session { get; set; }
        public Transcript Transcript { get; set; }


        [NotMapped]
        public AcademicYear AcademicYear => Session.AcademicYear;

        [NotMapped]
        public string CourseLevelName => Session.CourseLevel.Name;

        [NotMapped]
        public int CourseLevelId => Session.CourseLevel.Id;                           
    }
}
