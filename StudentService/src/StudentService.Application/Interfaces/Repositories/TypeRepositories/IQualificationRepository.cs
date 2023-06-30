using StudentService.Domain.Entities;


namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Qualification Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface IQualificationRepository : IGenericRepository<Qualification>
    {
    }

}