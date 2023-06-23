
using LibraryService.Domain.Common;
using System.Linq.Expressions;

namespace LibraryService.Application.Interfaces
{
    /// <summary>
    /// Generic Repository Interface.
    /// </summary>
    public interface IGenericRepository<T> where T : BaseAuditableEntity
    {
        /// <summary>
        /// Gets an entity by Id.
        /// </summary>
        /// <param name="predicate">Where clause.<example><code>x => x.Id == id</code></example></param>
        ///<returns>The entity object if found, otherwise null</returns>
        Task<T?> GetAsync(object key);

        /// <summary>
        /// Gets a single according that fullfills the <paramref name="predicate" />
        /// </summary>
        /// <param name="predicate">Where clause.<example><code>x => x.Id == id</code></example></param>
        ///<returns>The entity object if found, otherwise null</returns>
        Task<T?> GetByAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Retrives a collection of all entities
        /// </summary>
        /// <returns>A collections of all entities</returns>
        Task<IEnumerable<T?>> GetAllAsync();

        /// <summary>
        /// Retrieves a filtered and orderd collection of entities 
        /// </summary>
        /// <param name="predicate">Condition the entities must fullfill</param>
        /// <param name="orderBy">Collection order</param>
        /// <param name="includes">Any additional properies to be included</param>
        /// <returns>An ordered collection of entities</returns>
        Task<IEnumerable<T?>> GetAllOrderedAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>,
                                                                IOrderedQueryable<T>> orderBy = null,
                                                                string includeProperties = "");


        /// <summary>
        /// Retrieves a collection of entities that fullfills the <paramref name="predicate" />
        /// </summary>
        /// <param name="predicate">Condition the entities must fullfill
        /// <example>Example: x => x.Id == id</example>
        /// </param>
        /// <returns>A collection of entities</returns>
        Task<IEnumerable<T?>> GetAllWhereAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add an entity to the database
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The entity that was added</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update the specified entity 
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// /// <param name="entity">enity key</param>
        /// <returns>The entity updated entity</returns>
        Task<T> UpdateAsync(T entity);

        Task<T?> UpdateAsync(T entity, object key);

        /// <summary>
        /// Update multiple entities 
        /// </summary>
        /// <param name="entities">A collection of entities to update</param>
        /// <returns><see cref="Task"/></returns
        Task UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// This method deletes the specified record from the database 
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns><see cref="Task"/></returns
        Task Delete(T entity);



    }
}