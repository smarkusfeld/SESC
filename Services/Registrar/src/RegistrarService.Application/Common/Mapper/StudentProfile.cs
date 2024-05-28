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
            CreateMap<AddressDTO, Address>()
                .ReverseMap()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            CreateMap<NewStudentDTO, Student>()           
                 .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                 .ForMember(dest => dest.StudentEmail, opt => opt.Ignore())
                 .ForMember(dest => dest.Status, opt => opt.Ignore())
                 .ForMember(dest => dest.AlternateEmail, opt =>opt.MapFrom(src =>src.Email))
                 .ForMember(dest=>dest.Results, opt=>opt.Ignore())
                 .ForMember(dest => dest.Enrolments, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });

         

            CreateMap<UpdateStudentDTO, Student>()
                 .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                 .ForMember(dest => dest.StudentEmail, opt => opt.Ignore())
                 .ForMember(dest => dest.Status, opt => opt.Ignore())
                 .ForMember(dest => dest.AlternateEmail, opt => opt.MapFrom(src => src.AlternateEmail))
                  .ForMember(dest => dest.Results, opt => opt.Ignore())
                 .ForMember(dest => dest.Enrolments, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });

            CreateMap<Student, StudentAccountDTO>()
              .ForAllMembers(opts =>
              {
                  opts.AllowNull();
                  opts.Condition((src, dest, srcMember) => srcMember != null);
              });

            CreateMap<Student, StudentProgressionDTO>()
                .ForMember(dest=>dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });


            CreateMap<ProgressionDTO, ProgressionResult>()
            //.ForMember(dest => dest.CourseLevelName, opt => opt.MapFrom(src => src.CourseLevelName))
            .ForMember(dest => dest.ProgressDecision, opt => opt.MapFrom(src => src.ProgressDecision))
            .ForMember(dest => dest.ProgressDate, opt => opt.MapFrom(src => src.ProgressDate))
            .ForMember(dest => dest.ProgressNotes, opt => opt.MapFrom(src => src.ProgressNotes))
            //.ForMember(dest=> dest.AcademicYear, opt=>opt.Ignore())
            .ForMember(dest => dest.Student, opt => opt.Ignore())
            .ForMember(dest => dest.CourseLevel, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
            .ReverseMap()
            .ForPath(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.CourseLevel.AcademicYear.Name))
            .ForPath(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseLevel.Course.CourseCode));
            


        }
    }
}
