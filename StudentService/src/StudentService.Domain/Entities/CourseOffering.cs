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
    /// Course Offering Entity
    /// </summary>
    public class CourseOffering : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; } 
        public int QualificationId { get; set; }
        public int CourseId { get; set; }

        //navigation properties         
        public Qualification Qualification { get; set; }
        public Course Course { get; set; }
        public ICollection<Requirement> Requirements { get; private set; } = new List<Requirement>();


    }
}
