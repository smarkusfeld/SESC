using StudentService.Domain.Common;
using StudentService.Domain.ValueObjects;
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
        
        public override object Key => StudentId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNumber { get; set; }

        [Key]
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public int TranscriptId { get; set; }
        public string FullName => string.Concat(FirstName, MiddleName, Surname);

        //navigation properties
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public ICollection<CourseRegistration> Registrations { get; set; } = new List<CourseRegistration>();
        public Transcript Transcript { get; set; } 
        public Contact ContactDetail { get; set; }
        

       
    }
}
