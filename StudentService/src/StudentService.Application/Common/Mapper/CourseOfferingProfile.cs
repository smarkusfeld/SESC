using AutoMapper;
using StudentService.Application.Models.DTOs;
using StudentService.Domain.Entities;

namespace StudentService.Application.Common.Mapper
{
    public class CourseOfferingProfile : Profile
    {
        /// <summary>
        /// Automapper maps for course offering entity and related DTOs
        /// </summary>
        public CourseOfferingProfile()
        {
            CreateMap<CourseOfferingDTO, CourseOffering>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Qualification, opt => opt.Ignore())
              .ForMember(dest => dest.Course, opt => opt.Ignore())
              .ForMember(dest => dest.Requirements, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.QualificationTitle, opt => opt.MapFrom(src => src.Qualification.Title))
              .ForPath(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));

        }
    }
}
