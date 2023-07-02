using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Common;
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
        ICourseRepository Courses { get; }
        ICourseOfferingRepository CourseOfferings { get; }
        ICourseResultRepository CourseResults { get; }

        IDegreeRepository Degrees { get; }
        IEnrolmentRepository Enrolments { get; }
        IOfferRepository OfferResults { get; }
        IQualificationRepository Qualifications { get; }
        IRequirementRepository Requirements { get; }
        ITranscriptRepository Transcripts { get; }
        IStudentRepository Students { get; }
        ISchoolRepository Schools { get; }
        Task<int> Save();
        Task Rollback();
    }
}
