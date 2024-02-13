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
    public class AcademicYear : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        [NotMapped]
        public string Name => StartYear.ToString() + "/" + EndYear.ToString();
        public ICollection<AcademicTerm> AcademicTerms { get; set; } = new List<AcademicTerm>();

        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
