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
            CreateMap<EnrolmentDTO, Enrolment>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Student, opt => opt.Ignore())
              //.ForMember(dest => dest.Session, opt => opt.Ignore())
              .ReverseMap();
              //.ForPath(dest => dest.CourseLevelName, opt => opt.MapFrom(src => src.Session.CourseLevel.Name))
              //.ForPath(dest => dest.CourseCode, opt => opt.MapFrom(src => src.Session.CourseLevel.Course.CourseCode))
              //.ForPath(dest => dest.CourseName, opt => opt.MapFrom(src => src.Session.CourseLevel.Course.Name))
              //.ForPath(dest => dest.SessionModules, opt => opt.MapFrom(src => src.Session.SessionModules.Select(x => x.CourseModule.Name)));


        }
    }
}
