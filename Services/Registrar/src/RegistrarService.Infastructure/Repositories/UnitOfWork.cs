using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;
using RegistrarService.Infastructure.Repositories.TypeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        private ICourseRepository _courses;
        private IStudentRepository _students;
        private IAwardRepository _awards;
        private ISchoolRepository _schools;
        private ISubjectRepository _subjects;
        private IProgrammeRepository _programmes;
        private IApplicantRepository _applicants;
        private bool disposed;

        public ICourseRepository Courses => _courses ?? new CourseRepository(_dbContext);

        public IAwardRepository Awards => _awards ?? new AwardRepository(_dbContext);

        public IStudentRepository Students => _students ?? new AccountRepository(_dbContext);

        public ISchoolRepository Schools => _schools ?? new SchoolRepository(_dbContext);
        public ISubjectRepository Accounts => _subjects ?? new SubjectRepository(_dbContext);

        public IProgrammeRepository Programmes => _programmes ?? new ProgrammeRepository(_dbContext);

        public IApplicantRepository Applicants => throw new NotImplementedException();

        public ICourseApplicationRepository Applications => throw new NotImplementedException();

        IStudentRepository IUnitOfWork.Students => throw new NotImplementedException();

        public ISubjectRepository Subjects => throw new NotImplementedException();

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _students = Students;
            _schools = Schools;
            _subjects = Accounts;
            _courses = Courses;
            _awards = Awards;
            _students = Students;
               
        }
        /// <summary>
        /// Completes the unit of work, saving all repository changes to the underlying data-store.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }



        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <returns><see cref="ValueTask"/></returns>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing"></param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }



        /// <summary>
        /// Method to rollback database changes to its previous state
        /// </summary>
        /// <returns></returns>
        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }
    }
}