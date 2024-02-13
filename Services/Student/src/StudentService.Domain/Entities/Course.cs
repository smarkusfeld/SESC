using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Course Entity Aggregate Entity for <seealso cref="CourseLevel"/>, <seealso cref="CourseModule"/>, <seealso cref="Session"/>, <seealso cref="SessionModule"/>
    /// </summary>
    public class Course : BaseAuditableEntity, IAggregateRoot
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsActive { get; set; } = true; 
        public string Name { get; set; }

        public string CourseCode { get; set; } 
        public CourseType CourseType { get; set; }

        public int Duration { get; set; }
        public int SchoolId { get; set; }
        public int SubjectId { get; set; }
        public int AwardId { get; set; }


        //navigation properties     
        public School School { get; set; }

        public Subject Subject { get; set; }
        public Award Award { get; set; }
        public ICollection<CourseLevel> CourseLevels { get; private set; } = new List<CourseLevel>();
        public ICollection<ContainedAward> ContainedAwards { get; private set; } = new List<ContainedAward>();
        public ICollection<Registration> Registrations { get; private set; } = new List<Registration>();



        public IEnumerable<Session> ActiveSessions() => CourseLevels.SelectMany(x => x.ActiveSessions);

        public IEnumerable<Session> OpenSessions() => CourseLevels.SelectMany(x => x.OpenSessions);
       
        public IEnumerable<Session> ActiveSessionsByCourselevel(int courseLevelId) => CourseLevels.Where(x => x.Id == courseLevelId).SelectMany(x => x.ActiveSessions);

        public IEnumerable<Session> OpenSessionsByCourselevel(int courseLevelId) => CourseLevels.Where(x => x.Id == courseLevelId).SelectMany(x => x.OpenSessions);

        /// <summary>
        /// Add Course Level Module
        /// </summary>
        /// <param name="courseLevelId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
       public CourseLevel AddCourseLevelModules(int courseLevelId, string name)
       {
            var courseLevel = CourseLevels.Where(x => x.Id == courseLevelId).First();
            courseLevel.AddLevelModule(name);
            return courseLevel;

       }
        /// <summary>
        /// Add Session to Course Level
        /// </summary>
        /// <param name="courseLevelId"></param>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <returns>Updated Course Level</returns>
        public CourseLevel AddCourseLevelSession(int courseLevelId, AcademicYear year, AcademicTerm term)
        {
            var courseLevel = CourseLevels.Where(x => x.Id == courseLevelId).First();
            courseLevel.AddSession(year, term);
            return courseLevel;
        }
        /// <summary>
        /// Add Contained Award to Course
        /// </summary>
        /// <param name="awardId"></param>
        /// <returns>true if added, false if contained award already attached</returns>
        public bool AddContainedAward(int awardId)
        {
            if (ContainedAwards.Any(x => x.Id == awardId))
            {
                return false;
            }
            ContainedAwards.Add(new ContainedAward(awardId));
            return true;
        }
        /// <summary>
        /// Remove Contained Award from Course
        /// </summary>
        /// <param name="awardId"></param>
        /// <returns>true if removed, false if contained award not attached to course</returns>
        public bool RemoveContainedAward(int awardId)
        {
            if (ContainedAwards.Any(x => x.Id == awardId))
            {
                var award = ContainedAwards.First(x => x.Id == awardId);
                ContainedAwards.Remove(award);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get First Course Level for Course
        /// </summary>
        /// <returns>The <seealso cref="CourseLevel"/> with the lowest qualification level</returns>
        public CourseLevel GetFirstCourseLevel()
        {
            return CourseLevels.OrderBy(x => x.QualificationLevel).First();
        }

        

        /// <summary>
        /// Add courses levels to courses
        /// </summary>
        /// <param name="credits"></param>
        /// <param name="qualificationLevel"></param>
        /// <param name="tuition"></param>
        /// <returns>true if level added, false if course already has course level at that qualification level</returns>
        public bool AddCourseLevel(int credits, int qualificationLevel, float tuition)
        {
            if (CourseLevels.Any(x => x.QualificationLevel == qualificationLevel))
            {
                return false;
            }
            CourseLevels.Add(new CourseLevel(credits, qualificationLevel, tuition));
            return true;
        }
        /// <summary>
        /// Validate list of session ids for the specified course level
        /// </summary>
        /// <param name="courseLevelId"></param>
        /// <param name="sessionIdList"></param>
        /// <returns></returns>
        public bool ValidateSessionIdList(int courseLevelId, List<int> sessionIdList)
        {
            var levelSessions = CourseLevels.Where(x => x.Id == courseLevelId).SelectMany(x=>x.Sessions);
            foreach (var id in sessionIdList)
            {
                if (!levelSessions.Any(x => x.Id == id))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Open session enrollment for the session list
        /// </summary>
        /// <param name="courseLevelId"></param>
        /// <param name="sessionIdList"></param>
        /// <returns></returns>
        public CourseLevel OpenSessionEnrolment(int courseLevelId, List<int> sessionIdList)
        {
            var level = CourseLevels.Where(x => x.Id == courseLevelId).FirstOrDefault();
            level?.OpenSessionEnrolment(sessionIdList);
            return level;
        }
        /// <summary>
        /// Close session enrollment for the session list
        /// </summary>
        /// <param name="courseLevelId"></param>
        /// <param name="sessionIdList"></param>
        /// <returns></returns>
        public CourseLevel CloseSessionEnrolment(int courseLevelId, List<int> sessionIdList)
        {
            var level= CourseLevels.Where(x=>x.Id == courseLevelId).FirstOrDefault();
            level?.CloseSessionEnrolment(sessionIdList);
            return level;
        }
        /// <summary>
        /// Deactivate sessions for the session list
        /// </summary>
        /// <param name="courseLevelId"></param>
        /// <param name="sessionIdList"></param>
        /// <returns></returns>
        public CourseLevel DeactivateSessions(int courseLevelId, List<int> sessionIdList)
        {
            var level = CourseLevels.Where(x => x.Id == courseLevelId).FirstOrDefault();
            level?.DeactivateSessions(sessionIdList);
            return level;
        }

    }
   
}
