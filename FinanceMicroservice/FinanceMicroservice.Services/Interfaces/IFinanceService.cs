
using FinanceMicroservice.Core.Interfaces;
using FinanceMicroservice.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Services.Interfaces
{
    
    public interface IFinanceService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
