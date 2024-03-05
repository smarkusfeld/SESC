using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Common;
using RegistrarService.Domain.Interfaces;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Award Entity. 
    /// </summary>
    public class Award : BaseEntity 
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbr { get; set; }
        public int QualificationLevel { get; set; }
        public QualificationType QualificationType { get; set; }

        public DegreeCategory DegreeCategory { get; set; }

        //navigation properties

        public ICollection<Programme> Programmes { get; private set; } = new List<Programme>();

    }
}
