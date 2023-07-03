using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Trnascript entity 
    /// </summary>
    public class Transcript : BaseEntity
    {
        private Transcript() { }
        
        public Transcript(Student student, Course course)
        {
            Student = student;
            Course = course;
            Course = course;
            CourseId = course.Id;
            CourseName = course.Name;
        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int StudentId { get; private set; }
        public string CourseName { get; private set; }
        public int CourseId { get; private set; }

        //navigation properties
        public Student Student { get; private set; }

        //current course for the student
        public Course Course { get; private set; }
        public ICollection<CourseResult> Results { get; private set; } = new List<CourseResult>();

        public void UpdateCourse(int courseId, string courseName)
        {
            CourseId = courseId;
            CourseName = courseName;
        }
        
        /// <summary>
        /// Add or Update Single Course Result
        /// </summary>
        /// <param name="result"></param>
        public void AddUpdateResult(CourseResult result)
        {
            if (!Results.Any(x => x.CourseOfferingId == result.CourseOfferingId))
            {
                Results.Add(result);
            }
            else
            {
                var old = Results.Where(x => x.CourseOfferingId == result.CourseOfferingId).Single();
                Results.Remove(old);
                Results.Add(result);

            }
            
        }

        /// <summary>
        /// Add or Update A List of Course Results
        /// </summary>
        /// <param name="results"></param>
        public void AddUpdateResults(List<CourseResult> results)
        {
            foreach (var result in results)
            {
                if (!Results.Any(x => x.CourseOfferingId == result.CourseOfferingId))
                {
                    Results.Add(result);
                }
                else
                {
                    var old = Results.Where(x => x.CourseOfferingId == result.CourseOfferingId).Single();
                    Results.Remove(old);
                    Results.Add(result);

                }
            }
        }
    }
}
