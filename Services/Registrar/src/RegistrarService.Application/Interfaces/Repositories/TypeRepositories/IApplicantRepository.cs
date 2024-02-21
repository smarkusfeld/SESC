using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    /// <summary>
    /// Interface for ApplicantRepository. 
    /// <br></br> Implements the <see cref="IGenericRepository{T}"/>
    /// </summary>
    public interface IApplicantRepository : IGenericRepository<Applicant>
    {
        /// <summary>
        /// Submit Application for course
        /// </summary>
        /// <param name="entity">applicant entity with new application</param>
        /// <returns></returns>
        Task<Applicant> SubmitApplication(Applicant entity);

        /// <summary>
        /// Edit Application
        /// </summary>
        /// <param name="entity">applicant to be updated</param>
        /// <returns></returns>
        Task<CourseApplication> UpdateApplication(CourseApplication entity);


    }
}
