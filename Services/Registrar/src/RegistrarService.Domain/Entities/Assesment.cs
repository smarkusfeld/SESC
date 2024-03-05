using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;
using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    ///  Assesment Entity
    /// </summary>
    public class Assesment : BaseAuditableEntity
    {
        private Assesment() { }

        internal Assesment(int component, int result, int mark)
        {
            ComponentId = component;
            ResultId = result;
            Mark = mark;
        }
        public override object Key => AssesmentId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssesmentId { get; private set; }
        public int ComponentId { get; set; }
        public int ResultId { get; set; }

        public int Mark { get; set; }

        //navigation properties

        public Component Component { get; set; }
        public Result Result { get; set; }


    }
}
