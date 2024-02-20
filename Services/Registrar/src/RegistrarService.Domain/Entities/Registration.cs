using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarService.Domain.Common;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Registration Entity 
    /// </summary>
    public class Registration : BaseAuditableEntity
    {
        private Registration() { }

        public Registration(string studentId ,int sessionID)
        {
            StudentId = studentId;
            RegistrationDate = DateTime.Now;
        }
        
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public DateTime RegistrationDate { get; private set; }
        public string StudentId { get; private set; }
        public int SessionId { get; private set; }

        //navigation properies
        public Session Session { get; private set;}
        public Student Student { get; private set; }
    }
}
