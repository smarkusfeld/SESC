using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentService.Domain.Common.Enums;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Entrollment entity
    /// Part of the <seealso cref="Entities.Account"/> Entity Aggregate
    /// </summary>
    public class Enrolment : BaseAuditableEntity
    {

        private Enrolment() { }

        internal Enrolment(string studentId, int sessionId)
        {
            StudentId = studentId;
            SessionId = sessionId;
            EnrolDate = DateTime.Now;
            Status = EnrolStatus.Active;
        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public DateTime EnrolDate { get; private set; }
        public int SessionId { get; private set; }

        public string StudentId { get; private set; }
        public EnrolStatus Status { get; private set; }

        //navigation properties
        public Account? Account { get; private set; }       

        public Session Session { get; private set; }

        /// <summary>
        /// Update Enrolment Status
        /// </summary>
        /// <param name="newStatus"></param>
        public void UpdateStatus(EnrolStatus newStatus) 
        {
            Status = newStatus;
        }
    }
}
