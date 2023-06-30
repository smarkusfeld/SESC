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
    /// Trnascript entity 
    /// </summary>
    public class Transcript : BaseEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int StudentId { get; private set; }

        //navigation properties
        public Student Student { get; private set; }
        public ICollection<CourseResult>? Results { get; private set; } = new List<CourseResult>();
    }
}
