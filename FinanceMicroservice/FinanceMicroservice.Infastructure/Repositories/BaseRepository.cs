using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceMicroservice.Core.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using FinanceMicroservice.Infastructure.Context;

namespace FinanceMicroservice.Infastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DataContext DataContext { get; set; }

        public BaseRepository(DataContext context)
        {
            DataContext = context;
        }

        public IQueryable<T> FindAll() => DataContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DataContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => DataContext.Set<T>().Add(entity);
        public void Update(T entity) => DataContext.Set<T>().Update(entity);
        public void Delete(T entity) => DataContext.Set<T>().Remove(entity);
    }
}
