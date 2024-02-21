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
      
        public ICourseRepository Courses { get; }

        public IAwardRepository Awards { get; }

        public IStudentRepository Accounts { get; }

        public ISchoolRepository Schools { get; }
        public ISubjectRepository Subjects { get; }
        Task<int> Save();
        Task Rollback();
    }
}
