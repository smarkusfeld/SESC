using AutoMapper;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Common.Mapper
{

    public class StudentProfile : Profile
    {
        /// <summary>
        /// Automapper maps for student entity and related DTOs
        /// </summary>
        public StudentProfile()
        {
            CreateMap<StudentDTO, Student>()
              .ForMember(dest => dest.Key, opt => opt.Ignore())
              .ForMember(dest => dest.Enrolments, opt => opt.Ignore())
              .ForMember(dest => dest.Transcript, opt => opt.Ignore())
              .ForMember(dest => dest.TranscriptId, opt => opt.Ignore())
              .ForMember(dest => dest.ContactDetail, opt => opt.Ignore())
              .ForMember(dest => dest.Registrations, opt => opt.Ignore())
              .ReverseMap();


            CreateMap<Student, UpdateStudentContactDTO>()
             .ForMember(dest => dest.StudentEmail, opt => opt.MapFrom(src => src.ContactDetail.StudentEmail))
             .ForMember(dest => dest.AlternateEmail, opt => opt.MapFrom(src => src.ContactDetail.AlternateEmail))
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetail.PhoneNumber))
             .ForMember(dest => dest.TermAddressLineOne, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.LineOne))
             .ForMember(dest => dest.TermAddressLineTwo, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.LineTwo))
             .ForMember(dest => dest.TermAddressLineThree, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.LineThree))
             .ForMember(dest => dest.TermAddressTown_City, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.Town_City))
             .ForMember(dest => dest.TermAddressCounty_Region, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.County_Region))
             .ForMember(dest => dest.TermAddressPostCode, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.PostCode))
             .ForMember(dest => dest.TermAddressCountry, opt => opt.MapFrom(src => src.ContactDetail.TermAddress.Country))
             .ForMember(dest => dest.PermanentAddressLineOne, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.LineOne))
             .ForMember(dest => dest.PermanentAddressLineTwo, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.LineTwo))
             .ForMember(dest => dest.PermanentAddressLineThree, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.LineThree))
             .ForMember(dest => dest.PermanentAddressTown_City, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.Town_City))
             .ForMember(dest => dest.PermanentAddressCounty_Region, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.County_Region))
             .ForMember(dest => dest.PermanentAddressPostCode, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.PostCode))
             .ForMember(dest => dest.PermanentAddressCountry, opt => opt.MapFrom(src => src.ContactDetail.PermanentAddress.Country))
             .ReverseMap()
             .ForPath(dest => dest.Key, opt => opt.Ignore())
             .ForPath(dest => dest.Enrolments, opt => opt.Ignore())
             .ForPath(dest => dest.Transcript, opt => opt.Ignore())
             .ForPath(dest => dest.TranscriptId, opt => opt.Ignore());

            //reverse not created as transcript result should never be mapped to course result
            CreateMap<StudentResult, StudentTranscriptResultDTO>();

            //reverse not created as transcript is read only for the student user
            CreateMap<Transcript, StudentTranscriptDTO>()
                .ForMember(dest => dest.StudentFullName, opt => opt.MapFrom(src => src.Student.FullName))
                .ForMember(dest => dest.StudentSurname, opt => opt.MapFrom(src => src.Student.Surname))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));

        }
    }
}
