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

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Result Entity
    /// </summary>
    public class CourseResult : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string CourseName { get; set; }
        public string CourseOfferingName { get; set; }
        public ProgressDecision ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string ProgressNotes { get; set; } 
        public int TranscriptId { get; set; }
        public int QualificationId { get; set; }
        public int CourseOfferingId { get; set; }

        //navigation properties
        public Qualification Qualification { get; set; }
        public CourseOffering CourseOffering { get; set; }
       public Transcript Transcript { get; set; }

    }
}
