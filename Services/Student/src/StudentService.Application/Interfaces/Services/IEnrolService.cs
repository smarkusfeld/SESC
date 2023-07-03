using StudentService.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Services
{
    /// <summary>
    /// Defines a contract for enrolment services
    /// <br>Enrolmenr</br>
    /// </summary>
    public interface IEnrolService
    {
        /// <summary>
        /// All enrollments for the specified student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId);


        /// <summary>
        /// Accept offer, create new student account, and complete initial course course enrolment
        /// </summary>
        /// <param name="offer"></param>
        /// <returns>new student account</returns>
        Task<InitalRegistrationConfirmationDTO> RegisterNewStudent(StudentRegistrationDTO registration);

        /// <summary>
        /// Enrol in Course Offering
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseOfferingId"></param>
        /// <returns></returns>
        Task<EnrolmentConfirmationDTO> CourseEnrolment(string studentId, int courseOfferingId);

        /// <summary>
        /// Check Course Offering Eligibility for Student
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseOfferingId"></param>
        /// <returns></returns>
        Task<string> GetEligiableCourseOffering(string studentId, int courseOfferingId);
    }
}
