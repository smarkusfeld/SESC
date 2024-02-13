using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.Entities
{
    public class CourseModule : BaseAuditableEntity
    {
        private CourseModule() { }
        internal CourseModule(string name)
        {
            Name = name;
            IsActive = true;
        }
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public bool IsActive { get; set; }
        public string Name { get; private set; }

        public int CourseLevelId { get; private set; }

        public CourseLevel CourseLevel { get; private set;}
        public ICollection<SessionModule> SessionModules { get; private set; } = new List<SessionModule>();
    }
}
