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

            ////no reverse map needed for listings
            CreateMap<Course, CourseListingDTO>()
               .IncludeMembers(s => s.Programme)
               .ForMember(dest => dest.ProgrammeCode, opt => opt.MapFrom(src => src.ProgrammeCode));
            

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
               .ForPath(dest => dest.School, opt => opt.MapFrom(src => src.School.Name))
               .ForPath(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.Name))
               .ForPath(dest => dest.Award, opt => opt.MapFrom(src => src.Award.Name))
               .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
               .ForMember(dest => dest.Credits, opt => opt.MapFrom(src => src.TotalCredits));




        }
    }
}
