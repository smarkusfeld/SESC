using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Student Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>
    public interface IStudentRepository : IGenericRepository<Student>
    {

        /// <summary>
        /// Get Student Transcript and the course offering results for the student
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<Transcript> GetTranscriptAsync(string studentId);

    }
}
