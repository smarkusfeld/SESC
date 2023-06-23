using LibraryService.Application.Interfaces;
using LibraryService.Domain.Common;
using LibraryService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Persistence.Repositories
{
    /// <summary>
    /// Generic Abstract Repository class for performing Database Entity Operations.
    /// </summary>
    /// <typeparam name="T">The Type of Entity to operate on</typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _set;

     
        protected GenericRepository(DataContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IQueryable<T> Entities => _context.Set<T>();

        //public async Task<T> AddAsync(T entity)
        //{
           // await _set.AddAsync(entity);
           // return entity;
        //}
        public virtual async Task<T> UpdateAsync(T entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }
        public Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        //public async Task<List<T>> GetAllAsync()
        //{
           // return await _set.ToListAsync();
        //}

        public virtual async Task<T> GetByIdAsync(object key)
        {
            return await _set.FindAsync(key);
        }
        public virtual async Task<T?> GetAsync(object key) => await _set.AsNoTracking().SingleOrDefaultAsync(x =>x.Key==key);
        
        public virtual async Task<T?> GetByAsync(Expression<Func<T, bool>> predicate) => await _set.AsNoTracking().SingleOrDefaultAsync(predicate);

        
        public virtual async Task<IEnumerable<T?>> GetAllAsync() => await _set.AsNoTracking().ToListAsync();

        
        public virtual async Task<IEnumerable<T?>> GetAllOrderedAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>,
                                                                IOrderedQueryable<T>> orderBy = null,
                                                                string includeProperties = "")
        {

            IQueryable<T> query = _context.Set<T>();
            
            if (predicate != null)
            {

                query = query.Where(predicate);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                await orderBy(query).ToListAsync();
            }
            else
            {
                await query.AsNoTracking().ToListAsync();
            }
            return null;

        }




        
        public virtual async Task<IEnumerable<T?>> GetAllWhereAsync(Expression<Func<T, bool>> predicate) => await _set.Where(predicate).ToListAsync();

       
        public virtual async Task<T> AddAsync(T entity) 
        {
            await _set.AddAsync(entity);
            return entity;
        }

        
        public virtual void Update(T entity) => _set.Entry(entity).State = EntityState.Modified;

      
        public virtual async Task<T?> UpdateAsync(T entity, object key)
        {
            if (entity == null)
                return null;
            T exist = await _set.SingleOrDefaultAsync(x => x.Key == key);
            if (exist != null)            
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
            }
            return exist;

        }

        public virtual void Update(IEnumerable<T> entities) => _set.UpdateRange(entities);
       
        
        public virtual void Delete(T entity) => _set.Remove(entity);
       


    }
}