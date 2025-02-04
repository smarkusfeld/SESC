using AutoMapper;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Common.Mapper
{
    public class EnrolmentProfile : Profile
    {
        /// <summary>
        /// Automapper maps for enrolment entity and related DTOs
        /// </summary>
        public EnrolmentProfile()
        {

            CreateMap<Enrolment, EnrolmentDTO>()
                .IncludeMembers(s => s.CourseLevel)
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseLevelId, opt => opt.MapFrom(src => src.CourseLevelId))
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });
                          

            CreateMap<CourseLevel, EnrolmentDTO>()
               .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.CourseLevelId, opt => opt.Ignore())
               .ForPath(dest => dest.Tutition, opt => opt.MapFrom(src => src.TuitionFee))
               .ForPath(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Name))
               .ForAllMembers(opts =>
               {
                   opts.AllowNull();
                   opts.Condition((src, dest, srcMember) => srcMember != null);
               });


            CreateMap<EnrolmentDTO, Enrolment>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.Student, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.CourseLevel, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseLevel.Course.CourseCode));


        }
    }
}
