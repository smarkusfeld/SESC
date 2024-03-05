using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Component Entity owned by <seealso cref="CourseModule"/>
    /// </summary>
    public class Component : BaseAuditableEntity
    {
        private Component() { }
        internal Component(string name, int percent)
        {
            ComponentName = name;
            Percent = percent;
        }
        public override object Key => ComponentId;

        [Key]
        public string ComponentId { get; private set; }

        public string ComponentName { get; private set; }

        public int CRN { get; private set; }
        public int Percent { get; private set; }

        public CourseModule CourseModule { get; private set;}

        public ICollection<Assesment> Assesments { get; private set; } = new List<Assesment>();
    }
}
