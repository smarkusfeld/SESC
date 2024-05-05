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
    /// Account Entity. Aggregate Entity for <seealso cref="Transcript"/> , <seealso cref="Result"/>, <seealso cref="Enrolment"/>, <seealso cref="Registration"/>
    /// </summary>
    public class Student : BaseAuditableEntity, IAggregateRoot
    {
        /// <summary>
        /// Private Constructor for Database and Mapper
        /// </summary>
        private Student() { }

        /// <summary>
        /// Public Constructor for new account
        /// </summary>
        /// <param name="id"></param>
        public Student(int coursecode)
        {
            Transcript = new Transcript(coursecode);
        }
        public override object Key => StudentId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } 
        
        public string StudentEmail { get; set; }

        public StudentStatus Status { get; private set; }

        //navigation properties
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();

        public Transcript Transcript { get; set; }

       




    }
}
