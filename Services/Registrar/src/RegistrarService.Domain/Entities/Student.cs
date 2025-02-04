using RegistrarService.Domain.Common;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{
    /// <summary>
    /// Account Entity. Aggregate Entity for <seealso cref="Transcript"/> , <seealso cref="ProgressionResult"/>, <seealso cref="Enrolment"/>, <seealso cref="Registration"/>
    /// </summary>
    public class Student : BaseAuditableEntity, IAggregateRoot
    {


        /// <summary>
        /// Constructor for new Student account
        /// </summary>
        public Student()
        {}
        public override object Key => StudentId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } 

        
        public string StudentEmail { get; set; }

        public string AlternateEmail { get; set; }

        public StudentStatus Status { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }  

        public Address TermAddress { get; set; }

        public Address PermanentAddress { get; set; }


        //navigation properties

        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();

        public ICollection<ProgressionResult> Results { get; set; } = new List<ProgressionResult>();


    }
}
