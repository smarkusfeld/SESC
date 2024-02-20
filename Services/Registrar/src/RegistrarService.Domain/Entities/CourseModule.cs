using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Interfaces;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Course Module Level Entity
    /// Agggregate Entity for <seealso cref="Component"/>
    /// </summary>
    public class CourseModule : BaseAuditableEntity, IAggregateRoot
    {
        private CourseModule() { }
        internal CourseModule(string code, int term)
        {
            ModuleCode = code;
            AcademicTermId = term;
        }
        public override object Key => CRN;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CRN { get; private set; }

        public string Name { get; private set; }

        public int CourseLevelId { get; private set; }
        public int AcademicTermId { get; private set; }
        public CourseLevel CourseLevel { get; private set;}
        public string ModuleCode { get; private set; }

        public Module Module { get; private set; }

        public AcademicTerm AcademicTerm { get; private set; }
        public ICollection<Session> Sessions { get; private set; } = new List<Session>();
    }
}
