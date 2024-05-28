using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace RegistrarService.Application.Services
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

        public async Task<CourseListingDTO> GetCourse(string courseCode)
        {
            try
            {
                var result = await _unitOfWork.Courses.GetAsync(courseCode);
                return _mapper.Map<CourseListingDTO>(result);
            }
            catch
            {
                throw new KeyNotFoundException("Course code not found");
            }

        }
        public async Task<IEnumerable<CourseListingDTO>> GetAllCourses()
        {
            var result = await _unitOfWork.Courses.GetAllAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListingDTO>>(result);
            }
            return Enumerable.Empty<CourseListingDTO>();
        }
        public async Task<IEnumerable<CourseListingDTO>> GetAllActiveCourses()
        {

            //var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.IsActive == true, includeProperties: "CourseLevels");
            var result = await _unitOfWork.Courses.GetAllActiveCoursesAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListingDTO>>(result);
            }
            return Enumerable.Empty<CourseListingDTO>();
        }

        public async Task<IEnumerable<CourseListingDTO>> SearchCourseByAward(string searchAward)
        {
            var search = searchAward.ToLower();
            try
            {
                var check = await _unitOfWork.Awards.GetByAsync(x => x.Name.ToLower().Contains(search));

            }
            catch
            {
                throw new NotFoundException($"Search Error. Award: {searchAward} not found");
            }
            var result = await _unitOfWork.Programmes.GetAllOrderedAsync(filter: x => x.Award.Name.ToLower().Contains(search));
            if (result != null)
            {
                IEnumerable<Course> courses = new List<Course>();
                foreach (var programme in result)
                {
                    var programmeCourses = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.ProgrammeCode == programme.ProgrammeCode, includeProperties: "CourseLevels");
                    if (programmeCourses != null)
                    {
                        courses = courses.Concat(programmeCourses);
                    }

                }
                return _mapper.Map<IEnumerable<CourseListingDTO>>(courses);
            }
            return Enumerable.Empty<CourseListingDTO>();

        }

        public async Task<IEnumerable<CourseListingDTO>> SearchCourseBySchool(string searchSchool)
        {
            var search = searchSchool.ToLower();
            try
            {
                var check = await _unitOfWork.Schools.GetByAsync(x => x.Name.ToLower().Contains(search));

            }
            catch
            {
                 throw new NotFoundException($"Search Error. School: {searchSchool} not found");
            }
            
            var result = await _unitOfWork.Programmes.GetAllOrderedAsync(filter: x => x.School.Name.ToLower().Contains(search));
            if (result != null)
            {
                IEnumerable<Course> courses = new List<Course>();
                foreach (var programme in result)
                {
                    var programmeCourses = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.ProgrammeCode == programme.ProgrammeCode, includeProperties: "CourseLevels");
                    if (programmeCourses != null)
                    {
                        courses = courses.Concat(programmeCourses);
                    }

                }
                return _mapper.Map<IEnumerable<CourseListingDTO>>(courses);
            }
            return Enumerable.Empty<CourseListingDTO>();
        }
        public async Task<IEnumerable<CourseListingDTO>> SearchCourseBySubject(string searchSubject)
        {

            var search = searchSubject.ToLower();
            try
            {
                var check = await _unitOfWork.Subjects.GetByAsync(x => x.Name.ToLower().Contains(search));

            }
            catch
            {
                throw new NotFoundException($"Search Error. Subject: {searchSubject} not found");
            }            
            var result = await _unitOfWork.Programmes.GetAllOrderedAsync(filter: x => x.Subject.Name.ToLower().Contains(search));
            if (result != null)
            {
                IEnumerable<Course> courses = new List<Course>();
                foreach ( var programme in result)
                {
                    var programmeCourses = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.ProgrammeCode == programme.ProgrammeCode, includeProperties: "CourseLevels");
                    if (programmeCourses != null)
                    {
                        courses = courses.Concat(programmeCourses);
                    }
                    
                }
                return _mapper.Map<IEnumerable<CourseListingDTO>>(courses);
            }
            return Enumerable.Empty<CourseListingDTO>();
        }
        public async Task<IEnumerable<CourseListingDTO>> SearchCourseByName(string searchTitle)
        {            
            var result = await _unitOfWork.Programmes.GetAllOrderedAsync(filter: x => x.Name.ToLower().Contains(searchTitle));
            if (result != null)
            {
                IEnumerable<Course> courses = new List<Course>();
                foreach (var programme in result)
                {
                    var programmeCourses = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.ProgrammeCode == programme.ProgrammeCode, includeProperties: "CourseLevels");
                    if (programmeCourses != null)
                    {
                        courses = courses.Concat(programmeCourses);
                    }

                }
                return _mapper.Map<IEnumerable<CourseListingDTO>>(courses);
            }
            return Enumerable.Empty<CourseListingDTO>();
        }

        public async Task<IEnumerable<CourseListingDTO>> SearchCourseByType(string searchType)
        {
            try
            {
                Enum.TryParse(searchType, true, out CourseType search);
                var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.CourseType == search && x.IsActive == true, includeProperties: "CourseLevels");
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<CourseListingDTO>>(result);
                }
                return Enumerable.Empty<CourseListingDTO>();
            }
            catch 
            {
                throw new NotFoundException($"Course type: {searchType} not found");
            }        

        }

        

        public async Task<IEnumerable<CourseListingDTO>> GetCoursesByProgramme(string programmeCode)
        {
            try
            {
                var check = await _unitOfWork.Programmes.GetAsync(programmeCode);
               
            }
            catch
            {
                throw new NotFoundException($"Programme Code: {programmeCode} not found");
            }
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.ProgrammeCode == programmeCode, includeProperties: "CourseLevels");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListingDTO>>(result);
            }
            return Enumerable.Empty<CourseListingDTO>();
        }
    }
}
