﻿using StudentService.Application.Models.DTOs;
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
        Task<StudentDetailedDTO> UpdateContactInformation(StudentDetailedDTO studentDTO);

        /// <summary>
        /// Get student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="StudentDetailedDTO"/></returns>
        Task<StudentDTO> GetStudentAccount(string studentId);

        /// <summary>
        /// Get detailed student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="StudentDetailedDTO"/></returns>
        Task<StudentDetailedDTO> GetStudentAccountDetail(string studentId);

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
        /// <returns><seealso cref="ErrorDetails"/> if there are any validation errors, otherwise, null Task Result</returns>
        Task<ErrorDetail?>ValidateStudentAccountDetails (StudentDetailedDTO studentDTO);
    }
}
