using Azure;
using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using FinanceService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Infastructure.Repositories
{
    /// <summary>
    /// Generic Abstract Repository class for performing Database Entity Operations.
    /// </summary>
    /// <typeparam name="T">The Type of Entity to operate on</typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _set;

        protected GenericRepository(DataContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        /// <summary>
        /// Gets an entity by ID.
        /// </summary>
        /// <param name="id">Id of the entity to recievce </param>
        ///<returns>The entity object if found, otherwise null</returns>
        public async Task<T> GetAsync(int id) => await _set.SingleOrDefaultAsync(T => T.ID.Equals(id));

        /// <summary>
        /// Gets a single according that fullfills the <paramref name="predicate" />
        /// </summary>
        /// <param name="predicate">Where clause.<example><code>x => x.ID == id</code></example></param>
        ///<returns>The entity object if found, otherwise null</returns>
        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate) => await _set.SingleOrDefaultAsync(T => T.ID.Equals(predicate));

        /// <summary>
        /// Retrives a collection of all entities
        /// </summary>
        /// <returns>A collections of all entities</returns>
        public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();

        /// <summary>
        /// Retrieves a filtered and orderd collection of entities 
        /// </summary>
        /// <param name="filter">Condition the entities must fullfill</param>
        /// <param name="orderBy">Collection order</param>
        /// <param name="includes">Any additional properies to be included</param>
        /// <returns>An ordered collection of entities</returns>
        public async Task<IEnumerable<T>> GetAllOrderedAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
        {
           
            IQueryable<T> query = _context.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);
            if (filter != null)
            {
              
                query = query.Where(filter);
            }               

            if (orderBy != null)
            {
                await orderBy(query).ToListAsync();
            }
            else
            {
                await query.ToListAsync();
            }
            return null;
            
        }
        

        

        /// <summary>
        /// Retrieves a collection of entities that fullfills the <paramref name="predicate" />
        /// </summary>
        /// <param name="predicate">Condition the entities must fullfill
        /// <example>Example: x => x.ID == id</example>
        /// </param>
        /// <returns>A collection of entities</returns>
        public async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate) => await _set.Where(predicate).ToListAsync();

        /// <summary>
        /// Add an entity to the database
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The entity that was added</returns>
        public async Task<T> AddAsync(T entity) 
        {
            await _set.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Update the specified entity 
        /// </summary>
        /// <param name="entity">The entity to update</param>
        public void Update(T entity) => _set.Entry(entity).State = EntityState.Modified;
        

        /// <summary>
        /// Update multiple entities 
        /// </summary>
        /// <param name="entities">A collection of entities to update</param>
        public void Update(IEnumerable<T> entities) => _set.UpdateRange(entities);
       
        /// <summary>
        /// This method deletes the specified record from the database 
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns><see cref="Task"/></returns
        public void Delete(T entity) => _set.Remove(entity);
       


    }
}