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
            CreateMap<AddressDTO, Address>()
                .ReverseMap()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });



            CreateMap<CourseApplication, ApplicationDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.Applicant.ApplicantId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Applicant.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.Applicant.MiddleName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Applicant.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Applicant.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Applicant.Address))
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });


        }



    }
}
