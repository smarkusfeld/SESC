using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Services
{
    public interface IStudentAccountService
    {
        /// <summary>
        /// Update Student Contact Information
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns><see cref="StudentDTO"/></returns>
        Task<UpdateStudentContactDTO> UpdateContactInformation(UpdateStudentContactDTO studentDTO);

        /// <summary>
        /// Get student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="UpdateStudentContactDTO"/></returns>
        Task<StudentDTO> GetStudentAccount(string studentId);

        /// <summary>
        /// Get detailed student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="UpdateStudentContactDTO"/></returns>
        Task<UpdateStudentContactDTO> GetStudentAccountDetail(string studentId);

        /// <summary>
        /// Get student transcript
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="StudentDTO"/></returns>
        Task<StudentTranscriptDTO> GetStudentTranscript(string studentId);  

        /// <summary>
        /// Validate Student Account Details
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns>false if there are any validation errors, otherwise, true</returns>
        Task<bool>ValidateStudentAccountDetails (UpdateStudentContactDTO studentDTO);
    }
}
