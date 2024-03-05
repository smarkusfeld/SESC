using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RegistrarService.Domain.Entities
{
    public class AcademicModule : BaseAuditableEntity
    {
        private AcademicModule() { }
        internal AcademicModule(string code, string name)
        {
            ModuleCode = code;
            ModuleName = name;
        }
        public override object Key => ModuleCode;

        [Key]
        public string ModuleCode { get; private set; }

        public string ModuleName { get; private set; }

        public ICollection<CourseModule> CourseModules { get; private set; } = new List<CourseModule>();

    }
}
