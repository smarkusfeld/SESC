using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using FinanceService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Infastructure.Repositories
{
    ///<summary>
    /// This this is the abstract class for all repositories
    ///</summary>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        protected readonly DataContext _context;

        protected GenericRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<T?> Find(int id) => await _context.Set<T>().SingleOrDefaultAsync(T => T.ID.Equals(id));

        public async Task<T?> FindWhere(Expression<Func<T, bool>> predicate) => await _context.Set<T>().SingleOrDefaultAsync(T => T.ID.Equals(predicate));

        public async Task<List<T>> FindAll() => await _context.Set<T>().ToListAsync();
        public async Task<List<T>> FindAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
            {
                query = query.Where(filter);
            }               

            if (orderBy != null)
            {
                await orderBy(query).ToListAsync();
            }
            else
            {
                await query.ToListAsync();
            }
            return null;
            
        }
        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<List<T>> FindAllWhere(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity).State = EntityState.Modified;
        public void Update(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

       
    }
}