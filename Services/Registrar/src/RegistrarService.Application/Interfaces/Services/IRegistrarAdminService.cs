using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Services
{
    public interface IRegistrarAdminService
    {
        Task<NewCourseDTO> AddCourse(NewCourseDTO course);
        Task<NewCourseDTO> UpdateCourse(NewCourseDTO course);
        Task<NewCourseDTO> AddCourseLevel(NewCourseDTO course);
        Task<CourseLevelDTO> AddCourseLevelModules(CourseLevelDTO course);
        Task<CourseLevelDTO> AddCourseLevelSessions(CourseLevelDTO course);
        Task<CourseLevelDTO> OpenSessionEnrolment(CourseLevelDTO course);
        Task<CourseLevelDTO> CloseSessionEnrolment(CourseLevelDTO course);
        Task<CourseLevelDTO> DeactivateSessions(CourseLevelDTO course);
    }
}
