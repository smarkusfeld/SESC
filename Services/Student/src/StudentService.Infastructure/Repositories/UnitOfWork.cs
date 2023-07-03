using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private ICourseRepository _courses;
        private ICourseOfferingRepository _coursesOffering;
        private IStudentRepository _students;
        private ICourseResultRepository _results;
        private IDegreeRepository _degree;
        private ICourseEnrolmentRepository _courseEnrolments;
        private IQualificationRepository _qualifications;
        private IRequirementRepository _requirements;
        private ITranscriptRepository _transcripts;
        private ISchoolRepository _schools;

        private bool disposed;
        public ICourseRepository Courses => throw new NotImplementedException();
        //=> _courses ?? new CourseRepository(_dbContext);

        public ICourseOfferingRepository CourseOfferings => throw new NotImplementedException();

        public ICourseResultRepository CourseResults => throw new NotImplementedException();

        public IDegreeRepository Degrees => throw new NotImplementedException();

        public ICourseEnrolmentRepository CourseEnrolments => throw new NotImplementedException();

        public IEnrolmentRepository Enrolments => throw new NotImplementedException();

        public IQualificationRepository Qualifications => throw new NotImplementedException();

        public IRequirementRepository Requirements => throw new NotImplementedException();

        public ITranscriptRepository Transcripts => throw new NotImplementedException();

        public IStudentRepository Students => throw new NotImplementedException();

        public ISchoolRepository Schools => throw new NotImplementedException();

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
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