using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Level Entity
    /// Part of <seealso cref="Course"/> Aggregate Entity 
    /// </summary>
    public class CourseLevel : BaseAuditableEntity
    {
        private CourseLevel() { }

        internal CourseLevel(int credits, int qualificationLevel, float tuition) 
        {
            Credits = credits;
            QualificationLevel = qualificationLevel;
            TuitionFee = tuition;        
        }
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int Credits { get; set; }
        public int QualificationLevel { get; set; }
        public float TuitionFee { get; set; }
        public int CourseId { get; set; }

        // navigation properies
        public Course Course { get; set; }

        public ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

        [NotMapped]
        public string Name => Course.Name + QualificationLevel.ToString();

        [NotMapped]
        public IEnumerable<Session> ActiveSessions => Sessions.Where(s => s.IsActive) ?? new List<Session>();

        [NotMapped]
        public IEnumerable<Session> OpenSessions => Sessions.Where(s => s.EnrolmentOpen) ?? new List<Session>();

        /// <summary>
        /// Add Course Level Module
        /// </summary>
        internal void AddLevelModule(string name)
        {
            CourseModules.Add(new CourseModule(name));
        }

        /// <summary>
        /// Add Course Level Session with any active course modules,
        /// </summary>
        /// <param name="year"></param>
        /// <param name="term"></param>
        internal void AddSession(AcademicYear year, AcademicTerm term)
        {
            var modules = CourseModules.Where(x => x.IsActive).ToList() ?? new List<CourseModule>();
            Sessions.Add(new Session(year, term, modules));
        }

       
        /// <summary>
        /// Update session modules to reflect active course modules
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="modules"></param>
        /// <returns>true if updated, false if session cannot be updated</returns>
        internal bool UpdateSessionModules(int sessionId)
        {         

            var session = Sessions.Where(x=>x.Id == sessionId && x.IsActive).First();
            if(session != null)
            {
                var modules = CourseModules.Where(x => x.IsActive).ToList() ?? new List<CourseModule>();
                session.UpdateSessionModules(modules);
                return true;
            }
            return false; 
            
        }

        /// <summary>
        /// Open sessions for enrolment
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="modules"></param>
        /// <returns> true if all session ids exist, false any session ids are invalid</returns>
        internal bool OpenSessionEnrolment(List<int> sessionIdList)
        {
            if (sessionIdList.All(sessionId => Sessions.Any(x => x.Id == sessionId)))
            {
                foreach (var sessionId in sessionIdList)
                {
                    var session = Sessions.Where(x => x.Id == sessionId).First();
                    session.EnrolmentOpen = true;
                }
            }
            return false;
        }

        /// <summary>
        /// Close sessions for enrolment
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="modules"></param>
        /// <returns> true if all session ids exist, false any session ids are invalid</returns>
        internal bool CloseSessionEnrolment(List<int> sessionIdList)
        {
            if (sessionIdList.All(sessionId => Sessions.Any(x => x.Id == sessionId)))
            {
                foreach (var sessionId in sessionIdList)
                {
                    var session = Sessions.Where(x => x.Id == sessionId).First();
                    session.EnrolmentOpen = false;
                }
            }
            return false;
        }

        /// <summary>
        /// Mark Sessions as inactive
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="modules"></param>
        /// <returns> true if all session ids exist, false any session ids are invalid</returns>
        internal bool DeactivateSessions(List<int> sessionIdList)
        {
            if (sessionIdList.All(sessionId => Sessions.Any(x => x.Id == sessionId)))
            {
                foreach (var sessionId in sessionIdList)
                {
                    var session = Sessions.Where(x => x.Id == sessionId).First();
                    session.EnrolmentOpen = false;
                    session.IsActive = false;
                }
            }
            return false;
        }
    }
}
