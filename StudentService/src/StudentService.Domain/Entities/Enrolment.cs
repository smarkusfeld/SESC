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
    /// <summary>
    /// Entrollment entity
    /// </summary>
    public class Enrolment : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public DateTime EnrolDate { get; set; }
        
        public int CourseOfferingId { get; set; }
        //navigation properties
        public CourseOffering CourseOffering { get; set; }
        public ICollection<Student> Students { get; private set; } = new List<Student>();
    }
}
