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
     /// Course Offering Entity
    /// </summary>
    public class Offer: BaseAuditableEntity
    {
        public override object Key => OfferNumber;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferNumber { get; private set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public OfferStatus Status { get; set; } = OfferStatus.Pending;

        public DateTime DateIssued { get; set; }    

        public int CourseId { get; set; }
        public int? EnrolmentId { get; set; }

        //navigation properties
        public Course Course { get; set;}

        public Enrolment? Enrolment { get; set; }
    }
}
