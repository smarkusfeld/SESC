using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Interfaces
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<List<T>> FindAll();
        T FindByID(int ID);
        IQueryable<T> FindQueryable(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
        Task<List<T>> FindAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties);
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> FindAllAsync();

        T Create(T entity);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        bool Exists(int ID);

    }
}
