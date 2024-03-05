using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Course Entity. Contains all business logic and behaviors for course.
    /// </summary>
    public class Course : BaseAuditableEntity
    {
        public override object Key => CourseCode;

        [Key]
        public string CourseCode { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime ApplicationDeadline { get; set; }

        public DateTime EnrolmentDeadline { get; set; }

        public DateTime StartDate { get; set; } 

        public string ProgrammeCode { get; set; }


        public Programme Programme { get; set; }

        public CourseType CourseType { get; set; }

        //navigation properties     
        public ICollection<CourseLevel> CourseLevels { get; private set; } = new List<CourseLevel>();

        public ICollection<CourseApplication> CourseApplications { get; private set; } = new List<CourseApplication>();

        //read only properties 

        /// <summary>
        /// Enrolment Open read-only property for entity. Not mapped to database. Calculated based on <seealso cref="EnrolmentDeadline"/> 
        /// </summary>
        [NotMapped]
        public bool EnrolmentOpen { get => DateTime.Now <= EnrolmentDeadline ? true : false; }

        /// <summary>
        /// Enrolment Open read-only property for entity. Not mapped to database. Calculated based on <seealso cref="ApplicationDeadline"/> 
        /// </summary>
        [NotMapped]
        public bool ApplicationOpen { get => DateTime.Now <= ApplicationDeadline ? true : false; }

    }
   
}
