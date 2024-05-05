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
        private CourseLevel() { }

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
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Credits { get; set; }
        public int QualificationLevel { get; set; }
        public float TuitionFee { get; set; }
        public string CourseCode { get; set; }
        public int AcademicYearId { get; private set; }

        // navigation properies
        public Course Course { get; set; }

        public AcademicYear AcademicYear { get; private set; }

        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();

        [NotMapped]
        public string Name => Course.Programme.Name + QualificationLevel.ToString();

    }
}
