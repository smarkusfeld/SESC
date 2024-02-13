using StudentService.Domain.Entities;

namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Student Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>
    public interface IAccountRepository : IGenericRepository<Account>
    {
        /// <summary>
        /// Enrol Student in Course Level
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Account> CompleteEnrolment(Account entity);

        /// <summary>
        /// Register student in course
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Account> CompleteRegistration(Account entity);

        /// <summary>
        /// Add course results to student transcript
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Account> AddCourseResults(Account entity);
        /// <summary>
        /// Get last account number for generating the student Id
        /// </summary>
        /// <returns></returns>
        Task<string> GetNextStudentId();


    }
}
