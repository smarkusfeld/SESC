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
        public Student(string id)
        {
            StudentId = id;
            Transcript = new Transcript();
        }
        public override object Key => StudentId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentNumber { get; set; }

        [Key]
        public string StudentId { get; set; }
        
        public int CourseId { get; private set; }

        public StudentStatus Status { get; private set; }

        //navigation properties
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
        public Course Course { get; set; }

        public Transcript Transcript { get; set; }
       

        //methods for managing aggregate entity

        /// <summary>
        /// Register student for course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>false if student is already registered in the course, true if the student has been registered</returns>
        public bool Register(int courseId)
        {
            Transcript.AddUpdateCourse(courseId);
            //check student isn't already registered in course
            if(Registrations.Any(x => x.SessionId == courseId))
            {
                return false;
            }
            Registrations.Add( new Registration(StudentId, courseId));
            return true;
        }

        /// <summary>
        /// Enrol student in course level
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>true if enrolment is successful, false if student had already been enrolled in the course and not recieved a fail repeat status or 
        /// if there are no available course sessions</returns>
        public bool Enrol(int sessionId)
        {
            Enrolments.Add(new Enrolment(StudentId, sessionId) );
            return true;
        }


       
        /// <summary>
        /// Update Enrol Status for the student
        /// </summary>
        /// <param name="enrolmentId"></param>
        /// <param name="status"></param>
        public void UpdateEnrolStatus(int enrolmentId, EnrolStatus status)
        {
            var enrolment = Enrolments.Where(x => x.Id == enrolmentId).FirstOrDefault();
            enrolment.UpdateStatus(status);

        }
    }
}
