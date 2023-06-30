using StudentService.Application.Models.DTOs;
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
        Task<StudentDTO> UpdateContactInformation(StudentDTO studentDTO);

        /// <summary>
        /// Get student accouny
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="StudentDTO"/></returns>
        Task<StudentDTO> GetStudentAccount(string studentId);

        /// <summary>
        /// Get student transcript
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><see cref="StudentDTO"/></returns>
        Task<Transcript> GetStudentTranscript(string studentId);

        /// <summary>
        /// Check student graduation eligibility
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>true, if student is eligibile to graduate, false if not</returns>
        Task<bool> CheckGraduationEligibility(string studentId);


        /// <summary>
        /// Get all outstanding invoices for student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IEnumerable<OutstandingInvoiceDTO>> GetOutstandInvoices(string studentId);

        /// <summary>
        /// Get student outstanding balance
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<float> GetOutstandingBalance(string studentId);
    }
}
