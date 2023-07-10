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
    public class StudentResult : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string CourseLevelName { get; set; }
        public ProgressDecision ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string ProgressNotes { get; set; } 
        public int TranscriptId { get; set; }
        public int CourseLevelId { get; set; }


        //navigation properties
     
        public CourseLevel CourseLevel { get; set; }
       public Transcript Transcript { get; set; }

    }
}
