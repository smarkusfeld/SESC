using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Interfaces.Services
{
    /// <summary>
    /// Defines a contract for course services
    /// </summary>
    public interface ICourseService
    {

        /// <summary>
        /// Get All Courses
        /// </summary>
        /// <returns>>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> GetAllCourses();


        /// <summary>
        /// Get Course by CourseCode
        /// </summary>
        /// <param name="courseCode"><seealso cref="Course.CourseCode"/> course code</param>       
        /// <returns>>A  <seealso cref="CourseListing"/></returns>
        Task<CourseListing> GetCourse(string courseCode);

        /// <summary>
        /// Get Course by ProgrammeCode
        /// </summary>
        /// <param name="programmeCode"><seealso cref="Course.ProgrammeCode"/> course code</param>       
        /// <returns>>A <seealso cref="IEnumerable{CourseListingDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> GetCoursesByProgramme(string courseCode);

        /// <summary>
        /// Get All Active Courses
        /// </summary>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> GetAllActiveCourses();
        /// <summary>
        /// Filter Courses by CourseType
        /// </summary>
        /// <param name="seachType"><seealso cref="CourseType"/> search string</param>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> SearchCourseByType(string seachType);

        /// <summary>
        /// Filter Courses by School
        /// </summary>
        /// <exception cref="NotFoundException"></exception>
        /// <param name="searchSchool"><seealso cref="School"/> search string</param>       
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> SearchCourseBySchool(string searchSchool);

        /// <summary>
        /// Filter Courses by subject
        /// </summary>
        /// <param name="searchSubject"><seealso cref="School"/> search string</param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> SearchCourseBySubject(string searchSubject);
        /// <summary>
        /// Filter Courses by Degree
        /// </summary>
        /// <param name="searchAward"><seealso cref="Award"/> search string</param>
        /// <exception cref="NotFoundException"></exception>
        ///<returns>>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> SearchCourseByAward(string searchAward);

        /// <summary>
        /// Filter Courses by Name
        /// </summary>
        /// <param name="searchProgram"><seealso cref="Programme.Name"/> search string</param>
        /// <exception cref="NotFoundException"></exception>
        ///<returns>A <seealso cref="IEnumerable{CourseApplicationDTO}"/> of  <seealso cref="CourseListing"/> </returns>
        Task<IEnumerable<CourseListing>> SearchCoursebyName(string searchTitle);

       
    }
}
