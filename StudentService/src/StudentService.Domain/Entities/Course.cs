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
        public int Id { get; private set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public CourseType CourseType { get; set; }

        public int SchoolId { get; set; }
        public int DegreeId { get; set; }

        //navigation properties     
        public School School { get; set; }
        public Degree Degree { get; set; }
        public ICollection<CourseOffering> CourseOfferings { get; private set; } = new List<CourseOffering>();
    }
}
