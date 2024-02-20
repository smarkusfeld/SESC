using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Transcript Entity
    /// </summary>

    public class Transcript: BaseAuditableEntity
    {
        private Transcript() { }

        internal Transcript(string studentId, int coursecode)
        {
            StudentId = studentId;
            CourseCode = coursecode;
        }
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int CourseCode { get; private set; }
        public string StudentId { get; private set; }

        //navigation properties

        public Student Student { get; set; }
        public Course Course { get; set; }

        public ICollection<Result> Results { get; private set; } = new List<Result>();



    }
}
