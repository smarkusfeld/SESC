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
        
        public override object Key => AccountNumber;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNumber { get; private set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public int TranscriptId { get; set; }
        public string FullName => string.Concat(FirstName, MiddleName, Surname);

        //navigation properties
        public ICollection<Enrolment> Enrolments { get; private set; } = new List<Enrolment>();
        public ICollection<CourseRegistration> Registrations { get; private set; } = new List<CourseRegistration>();
        public Transcript Transcript { get; set; } 
        public Contact ContactDetail { get; set; }

        //methods for aggregate class

        /// <summary>
        /// Check if student is already registered for course
        /// </summary>
        /// <param name="course"></param>
        /// <returns>true, if student if already registered for course
        /// <br>false, if student is not registered for course</br></returns>
        public bool IsRegisteredForCourse(int courseId)
        {
            if (Registrations.Any())
            {
                return Registrations.Any(x => x.CourseId == courseId);
            }
            return false;
        }

        

       
    }
}
