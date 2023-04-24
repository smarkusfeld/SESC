using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
