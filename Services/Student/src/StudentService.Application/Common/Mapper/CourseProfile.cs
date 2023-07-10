using AutoMapper;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.ReponseModels;
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
              .ForMember(dest => dest.CourseLevels, opt => opt.Ignore())
              .ForMember(dest => dest.Registrations, opt => opt.Ignore())
              .ForMember(dest => dest.ContainedAwards, opt => opt.Ignore())
              .ForMember(dest => dest.School, opt => opt.Ignore())
              .ForMember(dest => dest.Subject, opt => opt.Ignore())
              .ForMember(dest => dest.Award, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
              .ForPath(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.Subject.Name))
              .ForPath(dest => dest.CourseDegree, opt => opt.MapFrom(src => src.Award.Name));

            CreateMap<CourseLevelDTO, CourseLevel>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Course, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
              .ForPath(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.CourseCode));
            CreateMap<Course, FullCourseListingDTO>()
               .ForMember(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
               .ForMember(dest => dest.CourseSubject, opt => opt.MapFrom(src => src.Subject.Name))
               .ForMember(dest => dest.CourseDegree, opt => opt.MapFrom(src => src.Award.Name))
               .ForMember(dest => dest.CourseLevels, opt => opt.MapFrom(src => src.CourseLevels.Select(x => x.Name)));

            CreateMap<Course, BasicCourseListingDTO>()
               .ForMember(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
               .ForMember(dest => dest.CourseSubject, opt => opt.MapFrom(src => src.Subject.Name))
               .ForMember(dest => dest.CourseDegree, opt => opt.MapFrom(src => src.Award.Name));

          
        }
    }
}
