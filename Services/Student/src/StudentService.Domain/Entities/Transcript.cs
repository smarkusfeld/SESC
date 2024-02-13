using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Common.Enums.StudentService.Domain.Common.Enums;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Transcript Entity owned by <seealso cref="Account"/>
    /// </summary>

    public class Transcript
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        internal Transcript() { }

        public int CourseId { get; private set; }

        //current course for the student
        public Course Course { get; private set; }

        
        public ICollection<CourseResult> Results { get; private set; } = new List<CourseResult>();

        [NotMapped]
        public string CourseName => Course.Name ?? string.Empty;

        [NotMapped]
        public string CourseCode => Course.CourseCode ?? string.Empty;

        /// <summary>
        /// Add or update course
        /// </summary>
        /// <param name="courseId"></param>
        public void AddUpdateCourse(int courseId)
        {
            CourseId = courseId;
        }

        /// <summary>
        /// Add new course result
        /// </summary>
        /// <param name="result"></param>
        public void AddCourseResult(string studentId, int sessionId, ProgressDecision progressDecision, string progressNotes)
        {
            var note = progressNotes ?? string.Empty;
            Results.Add(new CourseResult(studentId,sessionId, progressDecision, note));

        }

      
       

    }
}
