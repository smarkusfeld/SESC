using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using RegistrarService.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Services
{
    /// <summary>
    /// Defines a contract for enrolment services
    /// <br>Enrolmenr</br>
    /// </summary>
    public interface IEnrolService
    {


        /// <summary>
        /// Get all enrolments for the specified student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId);

        /// <summary>
        /// First time enrolment
        /// </summary>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="BadRequestException"></exception>
        
        Task<EnrolmentDTO> Enrol(int courseCode);

        /// <summary>
        /// Returning Student Enrolment
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="BadRequestException"></exception>
        Task<EnrolmentDTO> Enrol(int studentId, int courseCode);

    }
}
