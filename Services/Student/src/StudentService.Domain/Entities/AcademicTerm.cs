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
    public class AcademicTerm : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
