using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;
using StudentService.Infastructure.Repositories.TypeRepositories;
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
        private ICourseLevelRepository _coursesLevels;
        private IStudentRepository _students;
        private IStudentResultRepository _results;
        private IAwardRepository _awards;
        private ICourseRegistrationRepository _registrations;
        private ISchoolRepository _schools;
        private ISubjectRepository _subjects;
        private IEnrolmentRepository _enrolments;
        private bool disposed;

        public ICourseRegistrationRepository Registrations => _registrations ?? new CourseRegistrationRepository(_dbContext);
        public ICourseRepository Courses => _courses ?? new CourseRepository(_dbContext);
        public ICourseLevelRepository CourseLevels => _coursesLevels ?? new CourseLevelRepository(_dbContext);

        public IStudentResultRepository StudentResults => _results ?? new StudentResultRepository(_dbContext);

        public IAwardRepository Awards => _awards ?? new AwardRepository(_dbContext);

        public IEnrolmentRepository Enrolments => _enrolments ?? new EnrolmentRepository(_dbContext);

        public IStudentRepository Students => _students ?? new StudentRepository(_dbContext);

        public ISchoolRepository Schools => _schools ?? new SchoolRepository(_dbContext);
        public ISubjectRepository Subjects => _subjects ?? new SubjectRepository(_dbContext);
        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _students = Students;
            _enrolments = Enrolments;
            _schools = Schools;
            _subjects = Subjects;
            _courses = Courses;
            _coursesLevels = CourseLevels;
            _results = StudentResults;
            _awards = Awards;
            _enrolments = Enrolments;
            _students = Students;
            _registrations = Registrations;
               
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