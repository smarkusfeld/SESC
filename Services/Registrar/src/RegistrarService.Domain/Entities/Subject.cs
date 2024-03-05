using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Subject Entity 
    /// </summary>
    public class Subject : BaseAuditableEntity
    {
        public Subject() { }
        public Subject(int id, string name) { Id = id; Name = name; }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Name { get; set; }

        //navigation properties
        public ICollection<Programme> Programmes { get; private set; } = new List<Programme>();
    }
}