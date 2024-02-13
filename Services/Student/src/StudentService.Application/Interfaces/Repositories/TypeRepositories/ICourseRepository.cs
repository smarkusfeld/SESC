using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Course Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface ICourseRepository : IGenericRepository<Course>
    {
        
        
        /// <summary>
        /// Update Course contained awards
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Course> UpdateContainedAwardsAsync(Course entity);

        /// <summary>
        /// Method to update exisiting course levels as well as the associated course modules, sessions, and session modules
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<CourseLevel> UpdateCourseLevelAsync(CourseLevel entity);

 
    }

    
}
