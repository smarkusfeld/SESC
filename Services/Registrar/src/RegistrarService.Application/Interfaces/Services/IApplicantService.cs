using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Services
{
    public interface IApplicantService
    {
        /// <summary>
        /// Get all applicants
        /// </summary>
        /// <param name="newApplicant"></param>
        /// <returns> A list of <see cref="StudentAccountDTO"/></returns>
        Task<IEnumerable<ApplicantDTO>> GetAllApplicants();

        /// <summary>
        /// Get Applicant
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns><see cref="StudentAccountDTO"/></returns>
        Task<ApplicantDTO> GetApplicant(int applicantId);

        /// <summary>
        /// Update Applicant
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns><see cref="ApplicantDTO"/></returns>
        Task<ApplicantDTO> UpdateApplicant(UpdateApplicantDTO applicant);

        /// <summary>
        /// Create applicant
        /// </summary>
        /// <param name="newApplicant"></param>
        /// <returns><see cref="ApplicantDTO"/></returns>
        Task<ApplicantDTO> AddApplicant(NewApplicantDTO newApplicant);

    

    }
}
