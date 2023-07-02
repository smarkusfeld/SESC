using AutoMapper;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentCourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IEnumerable<CourseOfferingDTO>> GetAllCourseOfferings()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseListingDTO>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourse(string CourseName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourse(int CourseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourse(string studentId, int CourseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseListingDTO>> SearchCourseByDegree(string searchDegree)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseListingDTO>> SearchCourseBySchool(string searchSchool)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseListingDTO>> SearchCoursebyTitle(string searchTitle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseListingDTO>> SearchCourseByType(string seachType)
        {
            throw new NotImplementedException();
        }
    }
}
