using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Requirement Entity
    /// </summary>
    public class Requirement
    {
        public int QualificationId { get; set; }
        public int CourseOfferingId { get; set; }
        public Qualification Qualification { get; set; }
        public CourseOffering CourseOffering { get; set; }
    }
}
