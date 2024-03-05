using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using RegistrarService.Application.Common.Exceptions;

namespace RegistrarService.Application.Interfaces.Services
{
    /// <summary>
    /// Defines a contract for applicantion services
    /// </summary>
    public interface ICourseApplicantionService
    {


        /// <summary>
        /// Get All Applications 
        /// </summary>        
        /// <exception cref="NotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="CourseApplicationDTO"/></returns>
        Task<IEnumerable<CourseApplicationDTO>> GetAllApplications();

        /// <summary>
        /// Get All Applications by Applicant
        /// </summary>
        /// <param name="applicantId"><seealso cref="Applicant.ApplicantId"/> </param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="CourseApplicationDTO"/></returns>
        Task<IEnumerable<CourseApplicationDTO>> GetAllApplications(int applicantId);

        /// <summary>
        /// Get All Applications by Course
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="applicantId"><seealso cref="Course.CourseCode"/></param>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="CourseApplicationDTO"/></returns>
        Task<IEnumerable<CourseApplicationDTO>> GetAllApplicationsbyCourse(string courseCode);


        /// <summary>
        /// Get All Applications by Application Status
        /// </summary>
        /// <param name="appStatus"><seealso cref="CourseApplication.Status"/></param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="CourseApplicationDTO"/></returns>
        Task<IEnumerable<CourseApplicationDTO>> GetAllApplicationsbyStatus(string appStatus);

        /// <summary>
        /// Get Application
        /// </summary>
        /// <param name="applicantionId"><seealso cref="CourseApplication.ApplicationId"/> search string</param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <returns><seealso cref="CourseApplicationDTO"/></returns>
        Task<CourseApplicationDTO> GetApplication(int ApplicationId);

        /// <summary>
        /// Edit Application
        /// </summary>
        /// <param name="Applicantion"><seealso cref="ApplicationDTO"/> application to be updated</param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="BadRequestException"></exception>
        /// <returns><seealso cref="CourseApplicationDTO"/></returns>
        Task<CourseApplicationDTO> UpdateApplication(ApplicationDTO Applicantion);

        /// <summary>
        /// Add Application
        /// </summary>
        /// <param name="Applicantion"><seealso cref="NewApplicationDTO"/> application to be added</param>
        /// <exception cref="BadRequestException"></exception>
        /// <returns><seealso cref="CourseApplicationDTO"/></returns>
        Task<CourseApplicationDTO> AddApplication(NewApplicationDTO Applicantion);

        /// <summary>
        /// Accept Application Offer
        /// </summary>
        /// <param name="applicationId"><seealso cref="CourseApplication.ApplicationId"/> application id</param>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<CourseApplicationDTO> Accept(int ApplicationId);

        /// <summary>
        /// Decline Application Offer
        /// </summary>
        /// <param name="applicationId"><seealso cref="CourseApplication.ApplicationId"/> application id</param>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<CourseApplicationDTO> Decline(int ApplicationId);

        /// <summary>
        /// Withdraw Application
        /// </summary>
        /// <param name="applicationId"><seealso cref="CourseApplication.ApplicationId"/> application id</param>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<CourseApplicationDTO> Withdraw(int ApplicationId);
    }
}
