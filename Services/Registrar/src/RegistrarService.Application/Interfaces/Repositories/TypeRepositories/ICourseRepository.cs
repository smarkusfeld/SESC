using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Course Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface ICourseRepository : IGenericRepository<Course>
    {
        /// <summary>
        /// Retrives a collection of all courses
        /// </summary>
        /// <returns>An ordered collection of entities or empty collection of entities
        /// Expection returned if source is null</returns>
        /// <exception cref="NullReferenceException"></exception> 
        Task<IEnumerable<Course>> GetAllActiveCoursesAsync();


    }

    

}
