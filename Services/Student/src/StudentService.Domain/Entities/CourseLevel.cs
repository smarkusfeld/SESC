using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Level Entity
    /// </summary>
    public class CourseLevel : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Name { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public int Credits { get; set; } 
        public int QualificationLevel { get; set; }
        public float TuitionFee { get; set; }
        public int CourseId { get; set; }


        //navigation properties         
        public Course Course { get; set; }



    }
}
