using RegistrarService.Domain.Entities;
using System.Diagnostics.Contracts;

namespace RegistrarService.Application.Models.DTOs.ReponseModels
{
    /// <summary>
    /// Represents the <see cref="Course"/> for public views and searches
    /// <br> View only to protect data models</br>
    /// </summary>
    public class CourseListingDTO
    {
        public string CourseCode { get; set; }
        public bool IsActive { get; set; }

        //public string Name { get; private set; }

        public string CourseType { get; set; }
        public DateTime ApplicationDeadline { get; set; }

        public DateTime EnrolmentDeadline { get;  set; }
        public DateTime StartDate { get; set; }
        public bool EnrolmentOpen { get; set; }
        public bool ApplicationOpen { get; set; }
        public int Duration { get; set; }

        public int Credits { get; set; }

        public string ProgrammeCode { get; set; }

        public string School { get; set; }

        public string Subject { get; set; }

        public string Award { get; set; }

        public List<string> CourseLevels { get; set; }


    }
}
