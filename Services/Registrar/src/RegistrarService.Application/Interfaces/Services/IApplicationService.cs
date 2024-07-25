using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using RegistrarService.Application.Common.Exceptions;

namespace RegistrarService.Application.Interfaces.Services
{
    /// <summary>
    /// Defines a contract for applicantion services
    /// </summary>
    public interface IApplicationService
    {

        /// <summary>
        /// Get All Applications 
        /// </summary>        
        /// <exception cref="NotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="ApplicationDTO"/></returns>
        Task<IEnumerable<ApplicationDTO>> GetAllApplications();

        /// <summary>
        /// Get All Applications by Applicant
        /// </summary>
        /// <param name="applicantId"><seealso cref="Applicant.ApplicantId"/> </param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="ApplicationDTO"/></returns>
        Task<IEnumerable<ApplicationDTO>> GetAllApplications(int applicantId);

        /// <summary>
        /// Get All Applications by Course
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="applicantId"><seealso cref="Course.CourseCode"/></param>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="CourseApplicationDTO"/></returns>
        Task<IEnumerable<ApplicationDTO>> GetAllApplicationsbyCourse(string courseCode);


        /// <summary>
        /// Get All Applications by Application Status
        /// </summary>
        /// <param name="appStatus"><seealso cref="CourseApplication.Status"/></param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of <seealso cref="ApplicationDTO"/></returns>
        Task<IEnumerable<ApplicationDTO>> GetAllApplicationsbyStatus(string appStatus);

        /// <summary>
        /// Get Application
        /// </summary>
        /// <param name="applicantionId"><seealso cref="CourseApplication.ApplicationId"/> search string</param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <returns><seealso cref="ApplicationDTO"/></returns>
        Task<ApplicationDTO> GetApplication(int ApplicationId);



        /// <summary>
        /// Save Application
        /// </summary>
        /// <param name="applicantId">applicantId</param>
        /// <param name="courseCode">courseCode</param>
        /// <exception cref="BadRequestException"></exception>
        /// <returns><seealso cref="ApplicationDTO"/></returns>
        Task<ApplicationDTO> SaveApplication(int applicantId, string courseCode);

        /// <summary>
        /// Save Application
        /// </summary>
        /// <param name="inputModel"><seealso cref="NewApplicationDTO"/></param>
        /// <exception cref="BadRequestException"></exception>
        /// <returns><seealso cref="ApplicationDTO"/></returns>
        Task<ApplicationDTO> SaveApplication(NewApplicationDTO inputModel);

        /// <summary>
        /// Update Application
        /// </summary>
        /// <param name="inputModel"><seealso cref="UpdateApplicationDTO"/></param>
        /// <exception cref="BadRequestException"></exception>
        /// <returns><seealso cref="ApplicationDTO"/></returns>
        Task<ApplicationDTO> UpdateApplication(UpdateApplicationDTO inputModel);

        /// <summary>
        /// Submit Application
        /// </summary>
        /// <param name="applicantId">applicantId</param>
        /// <param name="courseCode">courseCode</param>
        /// <exception cref="BadRequestException"></exception>
        /// <returns><seealso cref="ApplicationDTO"/></returns>
        Task<ApplicationDTO> SubmitApplication(int applicationId);

        /// <summary>
        /// Accept Application Offer
        /// </summary>
        /// <param name="applicationId"><seealso cref="CourseApplication.ApplicationId"/> application id</param>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<ApplicationDTO> Accept(int ApplicationId);

        /// <summary>
        /// Decline Application Offer
        /// </summary>
        /// <param name="applicationId"><seealso cref="CourseApplication.ApplicationId"/> application id</param>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<ApplicationDTO> Decline(int ApplicationId);

        /// <summary>
        /// Withdraw Application
        /// </summary>
        /// <param name="applicationId"><seealso cref="CourseApplication.ApplicationId"/> application id</param>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<ApplicationDTO> Withdraw(int ApplicationId);
    }
}
