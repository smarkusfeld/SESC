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

    public class StudentProfile : Profile
    {
        /// <summary>
        /// Automapper maps for student entity and related DTOs
        /// </summary>
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
              .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.Transcript.CourseCode))
              .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Transcript.Course.Programme.Name));
              //.ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Transcript.Results));

            //CreateMap<Result, CourseResultDTO>()
                //.ForMember(dest => dest.CourseLevelName, opt => opt.MapFrom(src => src.CourseLevelName))
                //.ForMember(dest => dest.ProgressDecision, opt => opt.MapFrom(src => src.ProgressDecision))
                //.ForMember(dest => dest.ProgressDate, opt => opt.MapFrom(src => src.ProgressDate))
                //.ForMember(dest => dest.ProgressNotes, opt => opt.MapFrom(src => src.ProgressNotes))
                //.ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Name));



        }
    }
}
