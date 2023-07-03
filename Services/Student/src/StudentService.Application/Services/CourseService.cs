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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseOfferingDTO>> GetAllCourseOfferings()
        {
            var result = await _unitOfWork.CourseOfferings.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseOfferingDTO>>(result);
        }

        public async Task<IEnumerable<CourseListingDTO>> GetAllCourses()
        {
            var result = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseListingDTO>>(result);
        }

        public async Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourse(string courseName)
        {
            var normalizedName = courseName;
            var result = await _unitOfWork.CourseOfferings.GetAllWhereAsync(x=>x.Course.Name.Normalize() == courseName);
            return _mapper.Map<IEnumerable<CourseOfferingDTO>>(result);
        }

        public async Task<IEnumerable<CourseOfferingDTO>> GetCourseOfferingsByCourseCode(string courseCode)
        {
            
            var result = await _unitOfWork.CourseOfferings.GetAllWhereAsync(x => x.Course.CourseCode== courseCode);
            return _mapper.Map<IEnumerable<CourseOfferingDTO>>(result);
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
