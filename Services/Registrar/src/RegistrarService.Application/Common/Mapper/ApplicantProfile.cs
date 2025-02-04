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
    public class ApplicantProfile : Profile
    {
        /// <summary>
        /// Automapper maps for applicant entity and related DTOs
        /// </summary>
        public ApplicantProfile() 
        {



            CreateMap<Applicant, ApplicantDTO>()

              .ForMember(dest => dest.Applications, opt => opt.MapFrom(src => src.Applicantions.Select(x => x.ApplicationId)))
              .ForAllMembers(opts =>
              {
                  opts.AllowNull();
                  opts.Condition((src, dest, srcMember) => srcMember != null);
              });
      

            CreateMap<NewApplicantDTO, Applicant>()
                 .ForMember(dest => dest.ApplicantId, opt => opt.Ignore())
                 .ForMember(dest => dest.Applicantions, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });

            CreateMap<UpdateApplicantDTO, Applicant>()
                 .ForMember(dest => dest.Applicantions, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null); ;
                 });

      


        }
    }
}
