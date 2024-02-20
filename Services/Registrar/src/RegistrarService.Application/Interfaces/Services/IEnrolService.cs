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
        /// <exception cref="NotFoundException"></exception>
        Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId);

        /// <summary>
        /// Accept offer, create new student account, and complete initial course course enrolment
        /// </summary>
        /// <param name="offer"></param>
        /// <returns>new student account</returns>
        Task<TuitionInvoiceDTO> CourseRegistration(CourseRegistrationDTO courseRegistrationDTO);

        /// <summary>
        /// Enrol student already registered in a course in the eligible course offering level and session 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><seealso cref="TuitionInvoiceDTO"/></returns>
        Task<TuitionInvoiceDTO> Enrol(string studentId);

        /// <summary>
        /// Get course level for student enrolment according to eligibility
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        Task<CourseLevel?> GetEligiableCourseLevel(string studentId, Course course);

        /// <summary>
        /// Check if student is registered in course
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        Task<bool> CheckCourseRegistration(string studentId, int CourseId);

        /// <summary>
        /// Create invoice for student enrolment
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="session"></param>
        /// <returns><seealso cref="TuitionInvoiceDTO"/></returns>
        TuitionInvoiceDTO CreateInvoice(string studentId, Session session);

        /// <summary>
        /// Get eligible open session for next academic year for  student depending on student results 
        /// </summary>
        /// <param name="courseLevel"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        Session GetOpenSession(CourseLevel courseLevel, Student account);



    }
}
