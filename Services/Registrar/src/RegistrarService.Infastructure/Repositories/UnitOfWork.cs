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

        private IApplicantRepository _applicants;
        private IAwardRepository _awards;
        private ICourseRepository _courses;
        private ICourseLevelRepository _courseLevels;
        private ICourseApplicationRepository _applicantions;
        private IEnrolmentRepository _enrolments;
        private IProgrammeRepository _programmes;
        private IStudentRepository _students;
        private ISchoolRepository _schools;
        private ISubjectRepository _subjects;
        private IProgressionResultRepository _results;
        private bool disposed;


        public IApplicantRepository Applicants
        {
            get
            {
                _applicants ??= new ApplicantRepository(_dbContext);
                return _applicants;
            }
        }
        public IAwardRepository Awards
        {
            get
            {
                _awards ??= new AwardRepository(_dbContext);
                return _awards;
            }
        }
        public ICourseRepository Courses
        {
            get
            {
                _courses ??= new CourseRepository(_dbContext);
                return _courses;
            }
        }
        
        public ICourseLevelRepository CourseLevels
        {
            get
           {
                _courseLevels ??= new CourseLevelRepository(_dbContext);
               return _courseLevels;
           }
        }

        public ICourseApplicationRepository Applications
        {
            get
            {
                _applicantions ??= new CourseApplicationRepository(_dbContext);
                return _applicantions;
            }
        }
        public IEnrolmentRepository Enrolments
        {
            get
            {
                _enrolments ??= new EnrolmentRepository(_dbContext);
                return _enrolments;
            }
        }
        public IProgrammeRepository Programmes
        {
            get
            {
                _programmes ??= new ProgrammeRepository(_dbContext);
                return _programmes;
            }
        }

        public IProgressionResultRepository Results
        {
            get
            {
                _results ??= new ProgressionResultRepository(_dbContext);
                return _results;
            }
        }
        public IStudentRepository Students
        {
            get
            {
                _students ??= new StudentRepository(_dbContext);
                return _students;
            }
        }

        public ISchoolRepository Schools
        {
            get
            {
                _schools ??= new SchoolRepository(_dbContext);
                return _schools;
            }
        }
        public ISubjectRepository Subjects
        {
            get
            {
                _subjects ??= new SubjectRepository(_dbContext);
                return _subjects;
            }
        }

       

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            _students = Students;
            _schools = Schools;
            _subjects = Subjects;
            _courses = Courses;
            _courseLevels = CourseLevels;
            _awards = Awards;
            _applicantions = Applications;
            _applicants = Applicants;
            _programmes = Programmes;
            _enrolments = Enrolments;
            _results = Results;
             
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