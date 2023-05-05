using FinanceMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceMicroservice.Application.Interfaces
{
    ///<summary>
    /// This generic interface defines a contract for all repositories 
    ///</summary>
    ///<remarks>
    ///<see cref="IGenericRepository{T}"/>
    ///</remarks>
    public interface IGenericRepository<T> where T : IEntity
    {


        /// <summary>
        /// This method retrvies a single record from the database
        /// </summary>
        /// <param name="id">Database id</param>
        /// <returns> 
        /// A task that represents the asynchronous operation.
        /// The task result contains the database record of an arbirary  type, <typeparamref name="T"/>
        /// </returns>
        Task<T?> Find(int id);

        /// <summary>
        /// This method retrvies a single record from the database
        /// </summary>
        /// <param name="predicate">Where clause.
        /// <example><code>x => x.ID == id</code></example>
        /// </param>
        /// <returns> 
        /// A task that represents the asynchronous operation.
        /// The task result contains the database record of an arbirary  type, <typeparamref name="T"/>
        /// </returns>
        Task<T?> FindWhere(Expression<Func<T, bool>> predicate);
     
        /// <summary>
        /// This method retrvies all records of an arbirary type, <typeparamref name="T"/>
        /// </summary>
        /// <returns> 
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{T}" /> 
        /// </returns>
        Task<List<T>> FindAll();
        /// <summary>
        /// This method retrvies all records of an arbirary type, <typeparamref name="T"/>, using the <paramref name="predicate" /> 
        /// </summary>
        /// <param name="predicate">Example: x => x.ID == id</param>
        /// <returns> 
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{T}" /> 
        /// </returns>
        Task<List<T>> FindAllWhere(Expression<Func<T, bool>> predicate);

      
        /// <summary>
        /// This method creates a new record in the database
        /// </summary>
        /// <typeparamref name="T"/>
        /// <returns> 
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task Create(T entity);

        /// <summary>
        /// This method deletes the specified record from the database 
        /// </summary>
        /// <typeparamref name="T"/>
        void Delete(T entity);

        /// <summary>
        /// This method updates the specified entity in the database 
        /// </summary>
        /// <typeparamref name="T"/>
        void Update(T entity);

        /// <summary>
        /// This method updates the specified entity in the database 
        /// </summary>
        /// <param><see cref="IEnumerable{T}" /></param>
        void Update(IEnumerable<T> entities);  
        

    }
}
