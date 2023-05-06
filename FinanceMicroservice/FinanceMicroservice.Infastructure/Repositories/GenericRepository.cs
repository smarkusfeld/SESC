using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Interfaces;
using FinanceMicroservice.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceMicroservice.Application.Repositories
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

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<List<T>> FindAllWhere(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity).State = EntityState.Modified;
        public void Update(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);




    }
}
