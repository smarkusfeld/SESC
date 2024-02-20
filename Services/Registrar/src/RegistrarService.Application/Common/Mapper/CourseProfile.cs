using AutoMapper;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Application.Common.Mapper
{
    public class CourseProfile : Profile
    {
        /// <summary>
        /// Automapper maps for course entity and related DTOs
        /// </summary>
        public CourseProfile()
        {            
            CreateMap<NewCourseDTO, Course>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.CourseLevels, opt => opt.Ignore())
              .ForMember(dest => dest.Registrations, opt => opt.Ignore())
              .ForMember(dest => dest.ContainedAwards, opt => opt.Ignore())
              .ForMember(dest => dest.School, opt => opt.Ignore())
              .ForMember(dest => dest.Subject, opt => opt.Ignore())
              .ForMember(dest => dest.Award, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
              .ForPath(dest => dest.CourseSubject, opt => opt.MapFrom(src => src.Subject.Name))
              .ForPath(dest => dest.CourseAward, opt => opt.MapFrom(src => src.Award.Name))
              .ForPath(dest => dest.ContainedCourseAwards, opt => opt.MapFrom(src => src.ContainedAwards.Select(x=>x.Award.Name)));


            CreateMap<CourseModuleDTO, CourseModule>()
                .ForMember(dest => dest.Key, opt => opt.Ignore())
                .ForMember(dest => dest.CourseLevel, opt => opt.Ignore())
                .ForMember(dest => dest.SessionModules, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SessionDTO, Session>()
                .ForMember(dest => dest.Key, opt => opt.Ignore())
                .ForMember(dest => dest.AcademicYear, opt => opt.Ignore())
                .ForMember(dest => dest.AcademicTerm, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<CourseLevelDTO, CourseLevel>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Course, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.CourseModules, opt => opt.MapFrom(src => src.CourseModules))
              .ForPath(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));

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
