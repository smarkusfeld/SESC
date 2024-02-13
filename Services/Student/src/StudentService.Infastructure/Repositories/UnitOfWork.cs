﻿using StudentService.Application.Interfaces.Repositories;
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
        private IAccountRepository _students;
        private IAwardRepository _awards;
        private ISchoolRepository _schools;
        private ISubjectRepository _subjects;
        private bool disposed;

        public ICourseRepository Courses => _courses ?? new CourseRepository(_dbContext);

        public IAwardRepository Awards => _awards ?? new AwardRepository(_dbContext);

        public IAccountRepository Students => _students ?? new AccountRepository(_dbContext);

        public ISchoolRepository Schools => _schools ?? new SchoolRepository(_dbContext);
        public ISubjectRepository Accounts => _subjects ?? new SubjectRepository(_dbContext);
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