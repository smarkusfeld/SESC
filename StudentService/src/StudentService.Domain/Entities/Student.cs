using StudentService.Domain.Common;
using StudentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Student Entity
    /// </summary>
    public class Student : BaseAuditableEntity
    {
        public override object Key => AccountNumber;


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNumber { get; private set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public int TranscriptId { get; set; }

        public string FullName => string.Concat(FirstName, MiddleName, Surname);

        //navigation properties
        public ICollection<Enrolment> Enrolments { get; private set; } = new List<Enrolment>();
        public Transcript Transcript { get; set; }
        public Contact ContactDetail { get; set; }
    }
}
