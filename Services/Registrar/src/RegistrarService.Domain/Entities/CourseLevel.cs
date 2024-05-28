using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Course Level Entity. 
    /// </summary>
    public class CourseLevel : BaseAuditableEntity
    {
        public CourseLevel() { }

        /// <summary>
        /// Public Constructor to create CourseLevel
        /// </summary>
        /// <param name="course">Course Code</param>
        /// <param name="credits">Num of credits earned at level</param>
        /// <param name="year">AcademicYear Id</param>
        /// <param name="qualificationLevel">Qualification level of course level</param>
        /// <param name="tuition">Tution fee for course level</param>
        public CourseLevel(string course, int credits, int year, int qualificationLevel, float tuition)
        {
            CourseCode = course;
            Credits = credits;
            QualificationLevel = qualificationLevel;
            TuitionFee = tuition;
            AcademicYearId = year;
        }

        /// <summary>
        /// Internal Constructor to create CourseLevel used by <seealso cref="Course"/>
        /// </summary>
        /// <param name="credits">Num of credits earned at level</param>
        /// <param name="year">AcademicYear Id</param>
        /// <param name="qualificationLevel">Qualification level of course level</param>
        /// <param name="tuition">Tution fee for course level</param>
        internal CourseLevel(int credits, int year, int qualificationLevel, float tuition)
        {
            Credits = credits;
            QualificationLevel = qualificationLevel;
            TuitionFee = tuition;
            AcademicYearId = year;
        }
        public override object Key => CourseLevelId;

        private string _name;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseLevelId { get; set; }

        public int Credits { get; set; }
        public int QualificationLevel { get; set; }
        public double TuitionFee { get; set; }
        public string CourseCode { get; set; }
        public int AcademicYearId { get; set; }

        // navigation properies
        public Course Course { get; set; }

        public AcademicYear AcademicYear { get; private set; }

        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();

        public ICollection<ProgressionResult> Results { get; set; } = new List<ProgressionResult>();

        [NotMapped]
        public string Name => Course.Programme.Name + " "+  QualificationLevel.ToString();

    }
}
