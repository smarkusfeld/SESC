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
using System.Reflection;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Course Entity. Contains all business logic and behaviors for course.
    /// </summary>
    public class Course : BaseAuditableEntity
    {

        /// <summary>
        /// Internal Constructor for Course
        /// </summary>
        /// <param name="programmeCode"></param>
        /// <param name="courseCode"></param>
        /// <param name="courseType"></param>
        /// <param name="applicationDeadline"></param>
        /// <param name="enrolmentDeadline"></param>
        /// <param name="startDate"></param>
        /// <param name="isActive"></param>
        public Course(string programmeCode, string courseCode, CourseType courseType, DateTime applicationDeadline, DateTime enrolmentDeadline, DateTime startDate, bool isActive = true )
        {
            CourseCode = courseCode;
            IsActive = isActive;
            ApplicationDeadline = applicationDeadline;
            EnrolmentDeadline = enrolmentDeadline;
            StartDate = startDate;
            ProgrammeCode = programmeCode;
            CourseType = courseType;
        }

        public Course() { }
        public override object Key => CourseCode;

        [Key]
        public string CourseCode { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime ApplicationDeadline { get; set; }

        public DateTime EnrolmentDeadline { get; set; }

        public DateTime StartDate { get; set; } 

        public string ProgrammeCode { get; set; }

        //navigation properties     
        public Programme Programme { get; set; }

        public CourseType CourseType { get; set; }

        public ICollection<CourseLevel> CourseLevels { get; private set; } = new List<CourseLevel>();

        public ICollection<CourseApplication> CourseApplications { get; private set; } = new List<CourseApplication>();

        //read only properties 

        /// <summary>
        /// Enrolment Open read-only property for entity. Not mapped to database. Calculated based on <seealso cref="EnrolmentDeadline"/> 
        /// </summary>
        [NotMapped]
        public bool EnrolmentOpen { get => DateTime.Now <= EnrolmentDeadline; }

        /// <summary>
        /// Enrolment Open read-only property for entity. Not mapped to database. Calculated based on <seealso cref="ApplicationDeadline"/> 
        /// </summary>
        [NotMapped]
        public bool ApplicationOpen { get => DateTime.Now <= ApplicationDeadline; }

        

    }
   
}
