using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common;
using System.Reflection;
using System.Xml;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Session Entity
    /// </summary>
    public class Session : BaseAuditableEntity
    {
        private Session() { }


        public Session(int crn)
        {
            CRN = crn;
        }
        public override object Key => SessionCode;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionCode { get; set; }
        public int CRN { get; set; }

        public bool Open { get; set; } = true;

        public int Capacity { get; set; } = 30;

        public CourseModule CourseModule { get; set; }

        //navigation properties
        public ICollection<Timetable> Timetables { get; private set; } = new List<Timetable>();

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();

        [NotMapped]

        public int RegisteredStudents { get => Registrations.Count; }

        [NotMapped]

        public int Availablity{ get => Capacity - RegisteredStudents; }


    }
}
