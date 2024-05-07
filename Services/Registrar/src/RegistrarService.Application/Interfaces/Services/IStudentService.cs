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
    public interface IStudentService
    {
        /// <summary>
        /// Create student account
        /// </summary>
        /// <param name="newStudent"></param>
        /// <returns><see cref="StudentAccountDTO"/></returns>
        Task<StudentAccountDTO> AddStudentAccount(NewStudentDTO newStudent);

        /// <summary>
        /// Get student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="StudentAccountDTO"/></returns>
        Task<StudentAccountDTO> GetStudentAccount(int studentId);

        /// <summary>
        /// Add course level results to student account
        /// </summary>
        /// <param name="studentResult"></param>
        /// <returns><see cref="StudentAccountDTO"/></returns>
        Task<StudentProgressionDTO> AddProgressionResult(AddProgressionResultDTO result);

        /// <summary>
        /// Get all progression results for student 
        /// </summary>
        /// <param name="studentId"></param>        
        /// <returns><see cref="StudentAccountDTO"/></returns>
        Task<StudentProgressionDTO> GetProgressionResults(int studentId);


        /// <summary>
        /// Update student account
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="student"></param>
        /// <returns><see cref="StudentAccountDTO"/></returns>
        Task<StudentAccountDTO> UpdateStudentAccount(int studentId, UpdateStudentDTO student);
 

    }
}
