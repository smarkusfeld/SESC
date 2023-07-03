using StudentService.Domain.Entities;


namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Enrolment
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface IEnrolmentRepository : IGenericRepository<CourseRegistration>
    {
    }

}