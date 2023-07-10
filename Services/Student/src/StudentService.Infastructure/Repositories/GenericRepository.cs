﻿using Microsoft.EntityFrameworkCore;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Domain.Common;
using StudentService.Domain.Interfaces;
using StudentService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Repositories
{
    /// <summary>
    /// Generic Abstract Repository class for performing Database Entity Operations.
    /// </summary>
    /// <typeparam name="T">The Type of Entity to operate on</typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _set;


        protected GenericRepository(DataContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }


        public virtual async Task<T> GetAsync(object key) => await _set.AsNoTracking().SingleAsync(x => x.Key == key);

        public virtual async Task<T> GetByAsync(Expression<Func<T, bool>> predicate) => await _set.AsNoTracking().SingleAsync(predicate);


        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _set.AsNoTracking().ToListAsync();


        public virtual async Task<IEnumerable<T>> GetAllOrderedAsync(Expression<Func<T, bool>> filter = null,
                                                                    Func<IQueryable<T>, 
                                                                    IOrderedQueryable<T>> orderBy = null,
                                                                    string includeProperties = "")
        {

            IQueryable<T> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate) => await _set.Where(predicate).ToListAsync();

        public virtual async Task<T> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }        

        public virtual Task UpdateRange(IEnumerable<T> entities)
        {
            _set.UpdateRange(entities);
            return Task.CompletedTask;
        }


        public virtual Task Delete(T entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }



    }
}