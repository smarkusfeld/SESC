using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Student Entity
    /// </summary>
    public class Student : BaseAuditableEntity
    {
        public override object Key => StudentNumber;

        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentNumber { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]       
        public string StudentId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }  
        public string StudentEmail { get; set; }
        public string PersonalEmail { get; set; }
        public int TranscriptId { get; set; }

        //navigation properties
        public ICollection<Enrolment> Enrolments { get; private set; } = new List<Enrolment>();
        public Transcript Transcript { get; set; }
    }
}
