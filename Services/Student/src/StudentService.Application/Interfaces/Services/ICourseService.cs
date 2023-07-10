using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.ReponseModels;
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
        /// Get All Courses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FullCourseListingDTO>> GetAllCourses();

        /// <summary>
        /// Get All Active Courses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FullCourseListingDTO>> GetAllActiveCourses();
        /// <summary>
        /// Filter Courses by CourseType
        /// </summary>
        /// <param name="seachType"><seealso cref="CourseType"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> in the database </returns>
        Task<IEnumerable<FullCourseListingDTO>> SearchCourseByType(string seachType);

        /// <summary>
        /// Filter Courses by School
        /// </summary>
        /// <param name="searchSchool"><seealso cref="School"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<FullCourseListingDTO>> SearchCourseBySchool(string searchSchool);

        /// <summary>
        /// Filter Courses by subject
        /// </summary>
        /// <param name="searchSubject"><seealso cref="School"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<FullCourseListingDTO>> SearchCourseBySubject(string searchSubject);
        /// <summary>
        /// Filter Courses by Degree
        /// </summary>
        /// <param name="searchDegree"><seealso cref="Award"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<FullCourseListingDTO>> SearchCourseByAward(string searchDegree);

        /// <summary>
        /// Filter Courses by Title
        /// </summary>
        /// <param name="searchTitle"><seealso cref="Course.Name"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseListingDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<FullCourseListingDTO>> SearchCoursebyName(string searchTitle);

        /// <summary>
        /// Get all Course Offering
        /// </summary>
        /// <returns>A collection of all <seealso cref="CourseLevelDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<CourseLevelDTO>> GetAllCourseLevels();


        /// <summary>
        /// Filter CourseOffering by CourseName
        /// </summary>
        /// <param name="courseName"><seealso cref="Course"/> search string</param>
        /// <returns>A collection of all <seealso cref="CourseLevelDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<FullCourseListingDTO>> GetCourseLevelsByCourse(string courseName);

        /// <summary>
        /// Filter CourseOffering by CourseId
        /// </summary>
        /// <param name=" courseCode"></param>
        /// <returns>A collection of all <seealso cref="CourseLevelDTO"/> that satisfy the search critera</returns>
        Task<IEnumerable<FullCourseListingDTO>> GetCourseLevelsByCourseCode(string courseCode);

 

    }
}
