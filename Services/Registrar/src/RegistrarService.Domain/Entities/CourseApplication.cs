using RegistrarService.Domain.Common;
using RegistrarService.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Applicantion Entity for storing data related to prospective students 
    /// </summary>
    public class CourseApplication : BaseAuditableEntity
    {
        /// <summary>
        /// Private Constructor for Database and Mapper
        /// </summary>
        private CourseApplication() { }

        /// <summary>
        /// Public Constructor for new appplication
        /// </summary>
        /// <param name="applicantNumber">Applicant associated with application</param>
        /// /// <param name="courseCode">Course Associated with application</param>
        public CourseApplication(int applicantId, string courseCode)
        {
            ApplicantId = applicantId;
            CourseCode = courseCode;
        }
        public override object Key => ApplicantionId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantionId { get; set; }

        public string CourseCode { get; private set; }
        public int ApplicantId { get; private set; }
        public Applicant Applicant { get; private set; }
        public Course Course { get; private set; }
        public ApplicationStatus Status { get; private set; }

        public Enrolment? Enrolment { get; private set; }
    }
}
