using StudentService.Domain.Entities;
using System.Threading.Tasks;


namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for Transcript Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface ITranscriptRepository : IGenericRepository<Transcript>
    {
       
    }

}