using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Interfaces;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Timetable Entity stores session timetable data for scheduling classes
    /// </summary>
    public class Timetable : BaseAuditableEntity
    {
        private Timetable() { }


        public Timetable(int session)
        {
            SessionCode = session;
        }
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SessionCode { get; set; }
        public Session Session { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
