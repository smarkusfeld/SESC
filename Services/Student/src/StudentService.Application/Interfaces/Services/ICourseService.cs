using StudentService.Application.Models.DTOs;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Entities;

namespace StudentService.Application.Interfaces.Services
{
    /// <summary>
    /// Defines a contract for course services
    /// </summary>
    public interface ICourseService
    {

        /// <summary>
        /// Get All Available Courses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CourseListingDTO>> GetAllCourses();

        /// <summary>
        /// Filter Courses by CourseType
        /// </summary>
        /// <param name="seachType"><seealso cref="CourseType"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> in the database </returns>
        Task<IEnumerable<CourseListingDTO>> SearchCourseByType(string seachType);

        /// <summary>
        /// Filter Courses by School
        /// </summary>
        /// <param name="searchSchool"><seealso cref="School"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseListingDTO>> SearchCourseBySchool(string searchSchool);

        /// <summary>
        /// Filter Courses by Degree
        /// </summary>
        /// <param name="searchDegree"><seealso cref="Degree"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseListingDTO>> SearchCourseByDegree(string searchDegree);

        /// <summary>
        /// Filter Courses by Title
        /// </summary>
        /// <param name="searchTitle"><seealso cref="Course.Name"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseListingDTO>> SearchCoursebyTitle(string searchTitle);

        /// <summary>
        /// Get all Course Offering
        /// </summary>
        /// <returns>A collection of all <seealso cref="CourseOfferingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseOfferingDTO>> GetAllCourseOfferings();

        /// <summary>
        /// Filter CourseOffering by CourseName
        /// </summary>
        /// <param name="CourseName"><seealso cref="Course"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseOfferingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourse(string courseName);

        /// <summary>
        /// Filter CourseOffering by CourseId
        /// </summary>
        /// <param name="CourseName"></param>
        /// <returns>A collection of all <seealso cref="CourseOfferingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourseCode(string courseCode);

        /// <summary>
        /// Get all courses available for the specified student
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentId"></param>
        /// <returns>A collection of all <seealso cref="CourseOfferingDTO"/> that the student is eligable for </returns>
        Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourse(string studentId, int CourseId);

    }
}
