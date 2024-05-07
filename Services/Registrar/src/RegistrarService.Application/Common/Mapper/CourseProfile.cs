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
            //CreateMap<NewCourseDTO, Course>()
              //.ForMember(dest => dest.Key, opt => opt.Ignore())
              //.ForMember(dest => dest.CourseLevels, opt => opt.Ignore())
              //.ForMember(dest => dest.Registrations, opt => opt.Ignore())
              //.ForMember(dest => dest.ContainedAwards, opt => opt.Ignore())
              //.ForMember(dest => dest.School, opt => opt.Ignore())
              //.ForMember(dest => dest.Subject, opt => opt.Ignore())
              //.ForMember(dest => dest.Award, opt => opt.Ignore())
              //.ReverseMap();
              //.ForPath(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
              //.ForPath(dest => dest.CourseSubject, opt => opt.MapFrom(src => src.Subject.Name))
              //.ForPath(dest => dest.CourseAward, opt => opt.MapFrom(src => src.Award.Name))
              //.ForPath(dest => dest.ContainedCourseAwards, opt => opt.MapFrom(src => src.ContainedAwards.Select(x=>x.Award.Name)));


            ////no reverse map needed for listings
            //CreateMap<Course, CourseListing>()
            //   .ForMember(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.Programme.School.Name))
            //   .ForMember(dest => dest.CourseSubject, opt => opt.MapFrom(src => src.Programme.Subject.Name))
            //   .ForMember(dest => dest.CourseDegree, opt => opt.MapFrom(src => src.Programme.Award.Name))
            //   .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Programme.Duration))
            //   .ForMember(dest => dest.Credits, opt => opt.MapFrom(src => src.Programme.TotalCredits))
            //   .ForMember(dest => dest.ProgrammeCode, opt => opt.MapFrom(src => src.Programme.ProgrammeCode))
            //   .ForMember(dest => dest.CourseLevels, opt => opt.MapFrom(src => src.CourseLevels.Select(x => x.Name)));

            ////no reverse map needed for listings
            //CreateMap<CourseLevel, CourseLevelListing>()
            //    .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Name))
            //   .ForMember(dest => dest.CourseModules, opt => opt.MapFrom(src => src.CourseModules.Select(x => x.Name)));



        }
    }
}
