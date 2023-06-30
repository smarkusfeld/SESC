using AutoMapper;
using StudentService.Application.Models.DTOs;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Common.Mapper
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
              .ForMember(dest => dest.CourseOffering, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FullName))
              .ForPath(dest => dest.CourseOfferingName, opt => opt.MapFrom(src => src.CourseOffering.Name))
              .ForPath(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseOffering.Course.Name));

        }
    }
}
