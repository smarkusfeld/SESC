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
    public class Applicantion : BaseAuditableEntity
    {
        /// <summary>
        /// Private Constructor for Database and Mapper
        /// </summary>
        private Applicantion() { }

        /// <summary>
        /// Public Constructor for new appplication
        /// </summary>
        /// <param name="applicantNumber">Applicant associated with application</param>
        /// /// <param name="courseCode">Course Associated with application</param>
        public Applicantion(int applicantNumber, int courseCode)
        {
            ApplicantionNumber = applicantNumber;
            ApplicantionNumber = courseCode;
        }
        public override object Key => ApplicantionNumber;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantionNumber { get; set; }

        public int CourseCode { get; private set; }
        public int ApplicantId { get; private set; }
        public Applicant Applicant { get; private set; }
        public Course Course { get; private set; }
        public ApplicationStatus Status { get; private set; }

        public Enrolment? Enrolment { get; private set; }
    }
}
