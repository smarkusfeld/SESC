using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    /// <summary>
    /// Represents the <see cref="Course"/> for public views and searches
    /// <br> View only to protect data models</br>
    /// </summary>
    public class CourseListing
    {
        public string CourseCode { get; private set; }
        public string IsActive { get; private set; }

        public string Name { get; private set; }

        public string CourseType { get; private set; }
        public DateTime ApplicationDeadline { get; private set; }

        public DateTime EnrolmentDeadline { get;  private set; }
        public DateTime StartDate { get; private set; }
        public bool EnrolmentOpen { get; private set; }
        public bool ApplicationOpen { get; private set; }
        public int Duration { get; private set; }

        public int Credits { get; private set; }

        public string CourseSchool { get; private set; }

        public string CourseSubject { get; private set; }

        public string CourseDegree { get; private set; }

        public string ProgrammeCode { get; private set; }
        public List<string> CourseLevels { get; private set; }


    }
}
