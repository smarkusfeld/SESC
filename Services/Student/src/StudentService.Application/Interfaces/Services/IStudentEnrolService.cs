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
    public interface IStudentEnrolService
    {
        /// <summary>
        /// All enrollments for the specified student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<IEnumerable<EnrolmentDTO>> GetAllEnrolments(string studentId);

        /// <summary>
        /// Accept offer, create new student account, and complete course enrolment
        /// </summary>
        /// <param name="offer"></param>
        /// <returns>string representing the new student id</returns>
        Task<IEnumerable<EnrolmentDTO>> RegisterStudent(OfferDTO offer);

        /// <summary>
        /// Method to reject offer
        /// </summary>
        /// <param name="offer"></param>
        /// <returns>string representing the new student id</returns>
        Task<bool> RejectOffer(OfferDTO offer);

        /// <summary>
        /// Method for First Course Enrolment
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<EnrolmentDTO> InitialCourseEnrolment(string studentId, int courseId);

        /// <summary>
        /// Method to enrol in course offerings
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseOfferingId"></param>
        /// <returns></returns>
        Task<EnrolmentDTO> CourseOfferingEnrolment(string studentId, int courseOfferingId);
    }
}
