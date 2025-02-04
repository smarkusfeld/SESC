using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for CourseLevel Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>   
    public interface ICourseLevelRepository : IGenericRepository<CourseLevel>
    {
        /// <summary>
        /// Get first course level of course
        /// </summary>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        Task<CourseLevel?> GetFirstCourseLevel(string courseCode);
    }
}
