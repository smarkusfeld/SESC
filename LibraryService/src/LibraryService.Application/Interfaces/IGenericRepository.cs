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
    /// <typeparam name="T">The Type of <see cref="IEntity"/> to operate on</typeparam>
    public interface IGenericRepository<T> where T : IEntity
    {


        
        Task<T> GetAsync(int id);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);  
        Task<IEnumerable<T>> GetAllAsync();    
    
        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Update(IEnumerable<T> entities);


    }
}