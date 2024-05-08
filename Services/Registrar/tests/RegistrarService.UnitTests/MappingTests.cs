using AutoMapper;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Common.Mapper;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;

namespace RegistrarService.UnitTests
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _Mapper;
        public IMapper mapper { get { return _Mapper; } }
        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<EnrolmentProfile>();
                cfg.AddProfile<CourseProfile>();

            });
            _Mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        [Theory]
        [InlineData(typeof(NewStudentDTO), typeof(Student))]
        public void NewStudentInputModelMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(UpdateStudentDTO), typeof(Student))]
        public void UpdateStudentInputModelMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(Student), typeof(StudentAccountDTO))]
        public void StudentAccountResponseModelMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(Student), typeof(StudentProgressionDTO))]
        public void StudentResultResponseModelMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }

        [Theory]
        [InlineData(typeof(ProgressionResult), typeof(ProgressionDTO))]
        [InlineData(typeof(ProgressionDTO), typeof(ProgressionResult))]
        public void ProgressionResultMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }

        [Theory]
        [InlineData(typeof(EnrolmentDTO), typeof(Enrolment))]
        [InlineData(typeof(Enrolment), typeof(EnrolmentDTO))]
        public void EnrolmentMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(Course), typeof(CourseListingDTO))]
        public void PaymentMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
    }
}
