using AutoMapper;
using RegistrarService.Application.Common.Exceptions;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;
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


        public async Task<IEnumerable<CourseListing>> GetAllCourses()
        {
            var result = await _unitOfWork.Courses.GetAllAsync();
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();
        }
        public async Task<IEnumerable<CourseListing>> GetAllActiveCourses()
        {
            var result = await _unitOfWork.Courses.GetAllWhereAsync(x=>x.IsActive==true);
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();
        }

        public async Task<IEnumerable<CourseListing>> SearchCourseByAward(string searchAward)
        {
            var search = searchAward.ToLower();
            var check = await _unitOfWork.Awards.GetByAsync(x=>x.Name.ToLower().Equals(search))
                ?? throw new NotFoundException($"Search Error. Award: {searchAward} not found");
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x=>x.Programme.Award.Name.ToLower().Contains(search), includeProperties: "CourseLevels");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();

        }

        public async Task<IEnumerable<CourseListing>> SearchCourseBySchool(string searchSchool)
        {
            var search = searchSchool.ToLower();
            var check = await _unitOfWork.Schools.GetByAsync(x => x.Name.ToLower().Equals(search))
                ?? throw new NotFoundException($"Search Error. School: {searchSchool} not found");
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.Programme.School.Name.ToLower().Contains(search), includeProperties: "CourseLevels");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();
        }
        public async Task<IEnumerable<CourseListing>> SearchCourseBySubject(string searchSubject)
        {
            var search = searchSubject.ToLower();

            var check = await _unitOfWork.Subjects.GetByAsync(x => x.Name.ToLower().Equals(search))
                ?? throw new NotFoundException($"Search Error. Subject: {searchSubject} not found");
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.Programme.Subject.Name.ToLower().Contains(search), includeProperties: "CourseLevels");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();
        }
        public async Task<IEnumerable<CourseListing>> SearchCoursebyName(string searchTitle)
        {
            var search = searchTitle.ToLower();
            var check = await _unitOfWork.Programmes.GetByAsync(x => x.Name.ToLower().Equals(search))
                ?? throw new NotFoundException($"Search Error. Programme: {searchTitle} not found");

            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.Programme.Name.ToLower().Contains(search) && x.IsActive == true, includeProperties: "CourseLevels");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();
        }

        public async Task<IEnumerable<CourseListing>> SearchCourseByType(string searchType)
        {
            if (Enum.TryParse(searchType, true, out CourseType search))
            {
                var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.CourseType == search && x.IsActive == true, includeProperties: "CourseLevels");
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<CourseListing>>(result);
                }
                return Enumerable.Empty<CourseListing>();
            }
            throw new NotFoundException($"Course type: {searchType} not found");
        }

        public async Task<CourseListing> GetCourse(string courseCode)
        {
            var result = await _unitOfWork.Courses.GetAsync(courseCode)
                ?? throw new KeyNotFoundException($"Course code: {courseCode} not found");
            return _mapper.Map<CourseListing>(result);
        }

        public async Task<IEnumerable<CourseListing>> GetCoursesByProgramme(string programmeCode)
        {
            var check = await _unitOfWork.Programmes.GetAsync(programmeCode)
                ?? throw new NotFoundException($"Programme Code: {programmeCode} not found");
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.ProgrammeCode == programmeCode, includeProperties: "CourseLevels");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<CourseListing>>(result);
            }
            return Enumerable.Empty<CourseListing>();
        }
    }
}
