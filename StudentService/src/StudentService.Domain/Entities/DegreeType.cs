using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Common;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Degree Type Entity 
    /// </summary>
    public class DegreeType : BaseEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Name { get; set; }

        public DegreeLevel Level { get; set; }
    }
}
