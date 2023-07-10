using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentService.Domain.Common.Enums;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Entity
    /// </summary>
    public class Course : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsActive { get; set; } = true; 
        public string Name { get; set; }

        public string CourseCode { get; set; } 
        public CourseType CourseType { get; set; }

        public int Duration { get; set; }
        public int SchoolId { get; set; }
        public int SubjectId { get; set; }
        public int AwardId { get; set; }


        //navigation properties     
        public School School { get; set; }

        public Subject Subject { get; set; }
        public Award Award { get; set; }
        public ICollection<CourseLevel> CourseLevels { get; private set; } = new List<CourseLevel>();
        public ICollection<ContainedAward> ContainedAwards { get; private set; } = new List<ContainedAward>();
        public ICollection<CourseRegistration> Registrations { get; private set; } = new List<CourseRegistration>();
    }
}
