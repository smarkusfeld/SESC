using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common.Enums;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Entrollment entity
    /// </summary>
    public class Enrolment : BaseAuditableEntity
    {

        private Enrolment() { }

        internal Enrolment(string studentId, int courseLevelId)
        {
            StudentId = studentId;
            CourseLevelId = courseLevelId;
            EnrolDate = DateTime.Now;
            Status = EnrolStatus.Active;
        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public DateTime EnrolDate { get; private set; }
        public int CourseLevelId { get; private set; }

        public string StudentId { get; private set; }
        public EnrolStatus Status { get; private set; }

        //navigation properties
        public Student? Account { get; private set; }       

        public CourseLevel courseLevel { get; private set; }

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
