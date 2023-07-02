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
    public class TranscriptProfile : Profile
    {
        /// <summary>
        /// Automapper maps for transcript entity and related DTOs
        /// </summary>
        public TranscriptProfile()
        {
            //reverse not created as transcript result should never be mapped to course result
            CreateMap<CourseResult, StudentTranscriptResultDTO>();

            //reverse not created as transcript is read only for the student user
            CreateMap<Transcript, StudentTranscriptDTO>()
                .ForMember(dest => dest.StudentFullName, opt => opt.MapFrom(src => src.Student.FullName))
                .ForMember(dest => dest.StudentSurname, opt => opt.MapFrom(src => src.Student.Surname))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));

            CreateMap<CourseOfferingDTO, CourseOffering>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Qualification, opt => opt.Ignore())
              .ForMember(dest => dest.Course, opt => opt.Ignore())
              .ForMember(dest => dest.Requirements, opt => opt.Ignore())
              .ReverseMap()
              .ForPath(dest => dest.QualificationTitle, opt => opt.MapFrom(src => src.Qualification.Title))
              .ForPath(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));
        }
    }
}
