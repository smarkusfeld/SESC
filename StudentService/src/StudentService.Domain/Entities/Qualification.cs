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
    /// Qualification Entity 
    /// </summary>
    public class Qualification : BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Title { get; set; }

        public int QualificationId { get; set;}

        //navigation properties
        public ICollection<QualificationLevel> Level { get; private set; } = new List<QualificationLevel>();
    }
}
