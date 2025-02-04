using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for AcademicTerm Repository
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>    
    public interface IAcademicTermRepository : IGenericRepository<AcademicTerm>
    {
    }

}