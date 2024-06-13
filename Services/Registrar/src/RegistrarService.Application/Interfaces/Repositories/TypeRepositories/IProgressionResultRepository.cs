using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Result Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface IProgressionResultRepository : IGenericRepository<ProgressionResult>
    {

        /// <summary>
        /// Get all progression results for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProgressionResult>> GetStudentResults(int studentID);
    }
}
