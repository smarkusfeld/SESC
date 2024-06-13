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
            //  .ForMember(dest => dest.Key, opt => opt.Ignore())
            //  .ForMember(dest => dest.CourseLevels, opt => opt.Ignore())
            //  .ForMember(dest => dest.ContainedAwards, opt => opt.Ignore())
            //  .ForMember(dest => dest.School, opt => opt.Ignore())
            //  .ForMember(dest => dest.Subject, opt => opt.Ignore())
            //  .ForMember(dest => dest.Award, opt => opt.Ignore())
            //  .ReverseMap();
            //  .ForPath(dest => dest.CourseSchool, opt => opt.MapFrom(src => src.School.Name))
            //  .ForPath(dest => dest.CourseSubject, opt => opt.MapFrom(src => src.Subject.Name))
            //  .ForPath(dest => dest.CourseAward, opt => opt.MapFrom(src => src.Award.Name))
            //  .ForPath(dest => dest.ContainedCourseAwards, opt => opt.MapFrom(src => src.ContainedAwards.Select(x => x.Award.Name)));


            ////no reverse map needed for listings
            CreateMap<Course, CourseListingDTO>()
               .IncludeMembers(s => s.Programme)
               .ForMember(dest => dest.ProgrammeCode, opt => opt.MapFrom(src => src.ProgrammeCode))
               .ForMember(dest => dest.CourseLevels, opt => opt.MapFrom(src => src.CourseLevels.Select(x => x.Name)));
            


            CreateMap<Programme, CourseListingDTO>()
               .ForMember(dest => dest.CourseCode, opt => opt.Ignore())
               .ForMember(dest => dest.CourseType, opt => opt.Ignore())
               .ForMember(dest => dest.ApplicationDeadline, opt => opt.Ignore())
               .ForMember(dest => dest.EnrolmentDeadline, opt => opt.Ignore())
               .ForMember(dest => dest.IsActive, opt => opt.Ignore())
               .ForMember(dest => dest.EnrolmentOpen, opt => opt.Ignore())
               .ForMember(dest => dest.ApplicationOpen, opt => opt.Ignore())
               .ForMember(dest => dest.StartDate, opt => opt.Ignore())
               .ForMember(dest => dest.CourseLevels, opt => opt.Ignore())
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForPath(dest => dest.School, opt => opt.MapFrom(src => src.School.Name))
               .ForPath(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.Name))
               .ForPath(dest => dest.Award, opt => opt.MapFrom(src => src.Award.Name))
               .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
               .ForMember(dest => dest.Credits, opt => opt.MapFrom(src => src.TotalCredits));



            ////no reverse map needed for listings
            //CreateMap<CourseLevel, CourseLevelListing>()
            //    .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Name))
            //   .ForMember(dest => dest.CourseModules, opt => opt.MapFrom(src => src.CourseModules.Select(x => x.Name)));



        }
    }
}
