using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Models.DTOs.ReponseModels
{
    /// <summary>
    /// Data Transfer Object for transcript and course associated with the student 
    /// <br> View only to protect data models</br>
    /// </summary>
    public class AccountDTO
    {

        public string StudentId { get; set; }
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public IEnumerable<CourseResultDTO>? Results { get; private set; } = new List<CourseResultDTO>();


    }
    /// <summary>
    /// Data Transcript Object for the course offering results for <seealso cref="AccountDTO"/>
    /// <br> View only to protect data models</br>
    /// </summary>
    public class CourseResultDTO
    {
        public int Id { get; private set; }
        public string CourseLevelName { get; private set; }
        public string ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string ProgressNotes { get; set; }

        public string AcademicYear { get; set; }

    }
}
