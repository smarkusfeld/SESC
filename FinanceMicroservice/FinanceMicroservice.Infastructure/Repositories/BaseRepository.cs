using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FinanceMicroservice.Infastructure.Context;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Interfaces;
using FinanceMicroservice.Application.DTOs;
using System.Threading;

namespace FinanceMicroservice.Application.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        protected readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<T>> FindAll() => await _context.Set<T>().ToListAsync();

        public T FindByID(int ID) => SingleOrDefaultAsync(T => T.ID.Equals(ID)).Result;
        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            var query = _context.Set<T>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }
        public Task<List<T>> FindAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            var query = expression != null ? _context.Set<T>().Where(expression) : _context.Set<T>();
            return orderBy != null
               ? orderBy(query).ToListAsync()
               : query.ToListAsync();
        }
        public Task<List<T>> FindAllAsync() => _context.Set<T>().ToListAsync();
        public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            var query = _context.Set<T>().AsQueryable();
            return query.SingleOrDefaultAsync(expression);
        }
        public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties) 
        {
            var query = _context.Set<T>().AsQueryable();

            query = includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.SingleOrDefaultAsync(expression);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();
        public T Create(T entity) =>  _context.Set<T>().Add(entity).Entity;
        public void Update(T entity) => _context.Set<T>().Update(entity).State = EntityState.Modified;
        public void Update(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public bool Exists(int id)
        {
            if (FindByID(id) != null)
                return true;
            else
                return false;
        }

        


    }
}
