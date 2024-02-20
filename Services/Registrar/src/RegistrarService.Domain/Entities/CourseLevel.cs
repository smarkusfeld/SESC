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
    /// Course Level Entity
    /// </summary>
    public class CourseLevel : BaseAuditableEntity
    {
        private CourseLevel() { }

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
        public int CourseId { get; set; }
        public int AcademicYearId { get; private set; }

        // navigation properies
        public Course Course { get; set; }

        public AcademicYear AcademicYear { get; private set; }
        public ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

        [NotMapped]
        public string Name => Course.Programme.Name + QualificationLevel.ToString();

    }
}
