using AutoMapper;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Common.Mapper
{

    
    public class ApplicationProfile : Profile
    {
        /// <summary>
        /// Automapper maps for application entity and related DTOs
        /// </summary>
        public ApplicationProfile() 
        {

   

            CreateMap<CourseApplication, ApplicationDTO>()
                .IncludeMembers(s => s.Applicant)
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(src => src.ApplicationId))
                .ForMember(dest => dest.Statement, opt => opt.MapFrom(src => src.Statement))
                .ForPath(dest => dest.CourseCode, opt => opt.MapFrom(src => src.Course.CourseCode))
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });

             CreateMap<Applicant, ApplicationDTO>()
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.ApplicationId, opt => opt.Ignore())
               .ForMember(dest => dest.Statement, opt => opt.Ignore())
               .ForPath(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.ApplicantId))
               .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForPath(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
               .ForPath(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
               .ForPath(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForPath(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }



    }
}
