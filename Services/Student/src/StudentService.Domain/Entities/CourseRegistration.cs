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
    /// Course Registration
    /// </summary>
    public class CourseRegistration : BaseAuditableEntity
    {
        
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public DateTime RegistrationDate { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        //navigation properies
        public Course Course { get; set;}
        public Student Student { get; set;}
    }
}
