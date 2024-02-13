using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentService.Domain.Common;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Registration Entity
    /// Part of the <seealso cref="Account"/> Entity Aggregate
    /// </summary>
    public class Registration : BaseAuditableEntity
    {
        private Registration() { }

        public Registration(string studentId ,int courseID)
        {
            StudentId = studentId;
            CourseId = courseID;
            RegistrationDate = DateTime.Now;
        }
        
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public bool RegistrationConfirmed { get; set; }

        public DateTime RegistrationDate { get; private set; }
        public string StudentId { get; private set; }
        public int CourseId { get; private set; }

        //navigation properies
        public Course Course { get; private set;}
        public Account Account { get; private set; }
    }
}
