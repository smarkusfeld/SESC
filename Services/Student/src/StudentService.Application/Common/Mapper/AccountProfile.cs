using AutoMapper;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Application.Models.DTOs.ReponseModels;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Common.Mapper
{

    public class AccountProfile : Profile
    {
        /// <summary>
        /// Automapper maps for student entity and related DTOs
        /// </summary>
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
              .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Transcript.CourseId))
              .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Transcript.CourseName))
              .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Transcript.Results));

            CreateMap<CourseResult, CourseResultDTO>()
                .ForMember(dest => dest.CourseLevelName, opt => opt.MapFrom(src => src.CourseLevelName))
                .ForMember(dest => dest.ProgressDecision, opt => opt.MapFrom(src => src.ProgressDecision))
                .ForMember(dest => dest.ProgressDate, opt => opt.MapFrom(src => src.ProgressDate))
                .ForMember(dest => dest.ProgressNotes, opt => opt.MapFrom(src => src.ProgressNotes))
                .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Name));



        }
    }
}
