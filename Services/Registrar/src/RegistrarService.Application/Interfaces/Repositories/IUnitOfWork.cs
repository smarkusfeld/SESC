using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Common;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories
{
    ///<summary>
    /// This interface defines a contract for the unit of work class
    /// <br>UnitOfWork allows all repositories to share a single DataContext</br>
    ///</summary>
    public interface IUnitOfWork : IDisposable
    {

        public IProgrammeRepository Programmes { get; }
        public IApplicantRepository Applicants { get; }
        public ICourseApplicationRepository Applications { get; }
        public ICourseRepository Courses { get; }

        public ICourseLevelRepository CourseLevels { get; }
        public IEnrolmentRepository Enrolments { get; }
        public IAwardRepository Awards { get; }

        public IStudentRepository Students { get; }

        public ISchoolRepository Schools { get; }
        public ISubjectRepository Subjects { get; }

        public IProgressionResultRepository Results { get; }
        Task<int> Save();
        Task Rollback();
    }
}
