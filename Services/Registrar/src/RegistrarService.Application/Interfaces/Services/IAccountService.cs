using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Create student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="UpdateStudentContactDTO"/></returns>
        Task<StudentDTO> AddStudentAccount(int studentId);

        /// <summary>
        /// Get student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="UpdateStudentContactDTO"/></returns>
        Task<StudentDTO> GetStudentAccount(int studentId);

        /// <summary>
        /// Add course session results to student transcript
        /// </summary>
        /// <param name="studentResult"></param>
        /// <returns></returns>
        Task<StudentDTO> AddProgressionResult(ProgressionDTO progresion);

 

    }
}
