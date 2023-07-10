
using StudentService.Domain.Common.Enums;

namespace StudentService.Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for transcript and course associated with the student 
    /// <br> View only to protect data models</br>
    /// </summary>
    public class StudentTranscriptDTO
    {
        public int Id { get; set; }

        public string StudentId { get;  set; }

        public string StudentSurname { get; set; }

        public string StudentFullName { get;  set; }

        public string CourseName { get;  set; }
        
        public IEnumerable<StudentTranscriptResultDTO>? Results { get; private set; } = new List<StudentTranscriptResultDTO>(); 
        

    }
    /// <summary>
    /// Data Transcript Object for the course offering results for <seealso cref="StudentTranscriptDTO"/>
    /// <br> View only to protect data models</br>
    /// </summary>
    public class StudentTranscriptResultDTO
    {
        public int Id { get; private set;}
        public string CourseLevelName { get; private set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public string ProgressDecision { get; set; }
        public DateTime ProgressDate { get; set; }
        public string ProgressNotes { get; set; }
    }
}
