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
            CreateMap<NewStudentDTO, Student>()
                 .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                 .ForMember(dest => dest.StudentEmail, opt => opt.Ignore())
                 .ForMember(dest => dest.AlternateEmail, opt =>opt.MapFrom(src =>src.Email))
                 .ForMember(dest => dest.TermAddress.AddressLine1, opt => opt.MapFrom(src => src.TermAddressLine1))
                 .ForMember(dest => dest.TermAddress.AddressLine2, opt => opt.MapFrom(src => src.TermAddressLine2))
                 .ForMember(dest => dest.TermAddress.AddressLine3, opt => opt.MapFrom(src => src.TermAddressLine3))
                 .ForMember(dest => dest.TermAddress.City, opt => opt.MapFrom(src => src.TermAddressCity))
                 .ForMember(dest => dest.TermAddress.Region, opt => opt.MapFrom(src => src.TermAddressRegion))
                 .ForMember(dest => dest.TermAddress.Postcode, opt => opt.MapFrom(src => src.TermAddressPostcode))
                 .ForMember(dest => dest.TermAddress.Country, opt => opt.MapFrom(src => src.TermAddressCountry))
                 .ForMember(dest => dest.PermanentAddress.AddressLine1, opt => opt.MapFrom(src => src.PermanentAddressLine1))
                 .ForMember(dest => dest.PermanentAddress.AddressLine2, opt => opt.MapFrom(src => src.PermanentAddressLine2))
                 .ForMember(dest => dest.PermanentAddress.AddressLine3, opt => opt.MapFrom(src => src.PermanentAddressLine3))
                 .ForMember(dest => dest.PermanentAddress.City, opt => opt.MapFrom(src => src.PermanentAddressCity))
                 .ForMember(dest => dest.PermanentAddress.Region, opt => opt.MapFrom(src => src.PermanentAddressRegion))
                 .ForMember(dest => dest.PermanentAddress.Postcode, opt => opt.MapFrom(src => src.PermanentAddressPostcode))
                 .ForMember(dest => dest.PermanentAddress.Country, opt => opt.MapFrom(src => src.PermanentAddressCountry))
                 .ForAllMembers(opts =>
                 {
                     opts.AllowNull();
                     opts.Condition((src, dest, srcMember) => srcMember != null);
                 });

            CreateMap<Student, StudentAccountDTO>()
              .ForMember(dest => dest.TermAddressLine1, opt => opt.MapFrom(src => src.TermAddress.AddressLine1))
              .ForMember(dest => dest.TermAddressLine2, opt => opt.MapFrom(src => src.TermAddress.AddressLine2))
              .ForMember(dest => dest.TermAddressLine3, opt => opt.MapFrom(src => src.TermAddress.AddressLine3))
              .ForMember(dest => dest.TermAddressCity, opt => opt.MapFrom(src => src.TermAddress.City))
              .ForMember(dest => dest.TermAddressRegion, opt => opt.MapFrom(src => src.TermAddress.Region))
              .ForMember(dest => dest.TermAddressPostcode, opt => opt.MapFrom(src => src.TermAddress.Postcode))
              .ForMember(dest => dest.TermAddressCountry, opt => opt.MapFrom(src => src.TermAddress.Country))
              .ForMember(dest => dest.PermanentAddressLine1, opt => opt.MapFrom(src => src.PermanentAddress.AddressLine1))
              .ForMember(dest => dest.PermanentAddressLine2, opt => opt.MapFrom(src => src.PermanentAddress.AddressLine2))
              .ForMember(dest => dest.PermanentAddressLine3, opt => opt.MapFrom(src => src.PermanentAddress.AddressLine3))
              .ForMember(dest => dest.PermanentAddressCity, opt => opt.MapFrom(src => src.PermanentAddress.City))
              .ForMember(dest => dest.PermanentAddressRegion, opt => opt.MapFrom(src => src.PermanentAddress.Region))
              .ForMember(dest => dest.PermanentAddressPostcode, opt => opt.MapFrom(src => src.PermanentAddress.Postcode))
              .ForMember(dest => dest.PermanentAddressCountry, opt => opt.MapFrom(src => src.PermanentAddress.Country))
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
            

            CreateMap<ProgressionResult, ProgressionDTO>()
            .ForMember(dest => dest.CourseLevelName, opt => opt.MapFrom(src => src.CourseLevelName))
            .ForMember(dest => dest.ProgressDecision, opt => opt.MapFrom(src => src.ProgressDecision))
            .ForMember(dest => dest.ProgressDate, opt => opt.MapFrom(src => src.ProgressDate))
            .ForMember(dest => dest.ProgressNotes, opt => opt.MapFrom(src => src.ProgressNotes))
            .ForMember(dest => dest.AcademicYear, opt => opt.MapFrom(src => src.AcademicYear.Name));



        }
    }
}
