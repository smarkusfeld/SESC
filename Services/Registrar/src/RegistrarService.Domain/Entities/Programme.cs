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
    /// Program Entity 
    /// </summary>
    public class Programme : BaseAuditableEntity, IAggregateRoot
    {
        public override object Key => ProgrammeCode;

        [Key]
        public string ProgrammeCode { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public int TotalCredits { get; set; }

        public int SchoolId { get; set; }
        public int SubjectId { get; set; }
        public int AwardId { get; set; }

        //navigation properties     
        public School School { get; set; }

        public Subject Subject { get; set; }
        public Award Award { get; set; }
        public ICollection<Course> Courses { get; private set; } = new List<Course>();

  
    }
}
