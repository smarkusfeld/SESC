using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Student Repository 
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>
    public interface IStudentRepository : IGenericRepository<Student>
    {
        /// <summary>
        /// Enrol Student in Course Level
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Student> CompleteEnrolment(Student entity);

        /// <summary>
        /// Register student in course
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Student> CompleteRegistration(Student entity);

        /// <summary>
        /// Add course results to student transcript
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Student> AddCourseResults(Student entity);
        /// <summary>
        /// Get last account number for generating the student Id
        /// </summary>
        /// <returns></returns>
        Task<string> GetNextStudentId();


    }
}
