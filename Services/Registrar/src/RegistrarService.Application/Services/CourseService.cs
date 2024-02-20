using AutoMapper;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Common.Enums;

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
