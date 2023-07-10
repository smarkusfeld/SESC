using AutoMapper;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.ReponseModels;
using StudentService.Domain.Common.Enums;

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

        public async Task<IEnumerable<CourseLevelDTO>> GetAllCourseLevels()
        {
            var result = await _unitOfWork.CourseLevels.GetAllOrderedAsync(includeProperties: "CourseLevels");
            return _mapper.Map<IEnumerable<CourseLevelDTO>>(result);
        }

        public async Task<IEnumerable<FullCourseListingDTO>> GetAllCourses()
        {
            var result = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
        }
        public async Task<IEnumerable<FullCourseListingDTO>> GetAllActiveCourses()
        {
            var result = await _unitOfWork.Courses.GetAllWhereAsync(x=>x.IsActive==true);
            return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
        }

        public async Task<IEnumerable<FullCourseListingDTO>> GetCourseLevelsByCourse(string courseName)
        {
            var normalizedName = courseName;
            var result = await _unitOfWork.CourseLevels.GetAllWhereAsync(x=>x.Course.Name.Normalize() == courseName);
            return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
        }

        public async Task<IEnumerable<FullCourseListingDTO>> GetCourseLevelsByCourseCode(string courseCode)
        {
            
            var result = await _unitOfWork.CourseLevels.GetAllWhereAsync(x => x.Course.CourseCode== courseCode);
            return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
        }      

        public async Task<IEnumerable<FullCourseListingDTO>> SearchCourseByAward(string searchDegree)
        {
            var search = searchDegree.ToLower();
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x=>x.Award.Name.ToLower().Contains(search), includeProperties: "CourseOfferings");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
            }
            return Enumerable.Empty<FullCourseListingDTO>();

        }

        public async Task<IEnumerable<FullCourseListingDTO>> SearchCourseBySchool(string searchSchool)
        {
            var search = searchSchool.ToLower();
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.School.Name.ToLower().Contains(search), includeProperties: "CourseOfferings");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
            }
            return Enumerable.Empty<FullCourseListingDTO>();
        }
        public async Task<IEnumerable<FullCourseListingDTO>> SearchCourseBySubject(string searchSubject)
        {
            var search = searchSubject.ToLower();
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.Subject.Name.ToLower().Contains(search), includeProperties: "CourseOfferings");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
            }
            return Enumerable.Empty<FullCourseListingDTO>();
        }
        public async Task<IEnumerable<FullCourseListingDTO>> SearchCoursebyName(string searchTitle)
        {
            var search = searchTitle.ToLower();
            var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.Name.ToLower().Contains(search) && x.IsActive == true, includeProperties: "CourseOfferings");
            if (result != null)
            {
                return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
            }
            return Enumerable.Empty<FullCourseListingDTO>();
        }

        public async Task<IEnumerable<FullCourseListingDTO>> SearchCourseByType(string searchType)
        {
            if (Enum.TryParse(searchType, true, out CourseType search))
            {
                var result = await _unitOfWork.Courses.GetAllOrderedAsync(filter: x => x.CourseType == search && x.IsActive == true, includeProperties: "CourseOfferings" );
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<FullCourseListingDTO>>(result);
                }
            }                 
            return Enumerable.Empty<FullCourseListingDTO>();
        }

       
    }
}
