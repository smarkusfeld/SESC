using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceMicroservice.Domain.Entities;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using FinanceMicroservice.Infastructure.Context;
using FinanceMicroservice.Application.Interfaces;
using System.Data.Entity.Core.Common.CommandTrees;
using FinanceMicroservice.Domain.Interfaces;

namespace FinanceMicroservice.Application.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        protected readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByID(int id) => FindByCondition(T => T.ID.Equals(id));
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
