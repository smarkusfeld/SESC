using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// Generic Repository Interface.
    /// </summary>
    public interface IGenericRepository<T> where T : class
    {        
        Task<T> GetAsync(int id);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);  
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllOrderedAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>,
                                                                IOrderedQueryable<T>> orderBy = null,
                                                                string includeProperties = "");
        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Update(IEnumerable<T> entities);

    }
}