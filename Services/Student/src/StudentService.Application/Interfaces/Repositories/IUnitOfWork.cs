using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Common;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Repositories
{
    ///<summary>
    /// This interface defines a contract for the unit of work class
    /// <br>UnitOfWork allows all repositories to share a single DataContext</br>
    ///</summary>
    public interface IUnitOfWork : IDisposable
    {
        public ICourseRegistrationRepository Registrations { get; }
        public ICourseRepository Courses { get; }
        public ICourseLevelRepository CourseLevels { get; }

        public IStudentResultRepository StudentResults { get; }

        public IAwardRepository Awards { get; }

        public IEnrolmentRepository Enrolments { get; }

        public IStudentRepository Students { get; }

        public ISchoolRepository Schools { get; }
        public ISubjectRepository Subjects { get; }
        Task<int> Save();
        Task Rollback();
    }
}
