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
    /// ContainedAward Entity 
    /// </summary>
    public class ContainedAward : BaseEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CourseId;
        public int AwardId;

        public Course Course { get; set; }
        public Award Award { get; set; }
    }
}
