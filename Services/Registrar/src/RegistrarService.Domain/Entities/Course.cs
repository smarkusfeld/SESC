using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Course Entity 
    /// </summary>
    public class Course : BaseAuditableEntity, IAggregateRoot
    {
        public override object Key => CourseCode;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseCode { get; set; }

        public bool Active { get; set; } = true;

        public DateTime StartDate { get; set; } 

        public string ProgrammeCode { get; set; }


        public Programme Programme { get; set; }

        public CourseType CourseType { get; set; }

        //navigation properties     
        public ICollection<CourseLevel> CourseLevels { get; private set; } = new List<CourseLevel>();


    }
   
}
