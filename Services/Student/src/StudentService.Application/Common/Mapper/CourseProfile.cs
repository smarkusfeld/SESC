using AutoMapper;
using StudentService.Application.Models.DTOs;
using StudentService.Domain.Entities;

namespace StudentService.Application.Common.Mapper
{
    public class CourseProfile : Profile
    {
        /// <summary>
        /// Automapper maps for course entity and related DTOs
        /// </summary>
        public CourseProfile()
        {            
            CreateMap<CourseDTO, Course>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.CourseOfferings, opt => opt.Ignore())
              .ForMember(dest => dest.Offers, opt => opt.Ignore())
              .ForMember(dest => dest.School, opt => opt.Ignore())
              .ForMember(dest => dest.Degree, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
              .ForPath(dest => dest.CourseDegree, opt => opt.MapFrom(src => src.Degree.Name));

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
