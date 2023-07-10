using AutoMapper;
using StudentService.Application.Common.Mapper;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Application.Models.DTOs.ReponseModels;
using StudentService.Domain.Entities;
using System.Runtime.Serialization;
using Xunit;

namespace StudentService.Tests
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _Mapper;
        public IMapper Mapper { get { return _Mapper; } }
        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CourseProfile>();
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<EnrolmentProfile>();

            });
            _Mapper = _configuration.CreateMapper();
        }
        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        [Theory]
        [InlineData(typeof(StudentDTO), typeof(Student))]
        [InlineData(typeof(Student), typeof(StudentDTO))]
        public void StudentMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(UpdateStudentContactDTO), typeof(Student))]
        [InlineData(typeof(Student), typeof(UpdateStudentContactDTO))]
        public void StudentDetailMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(StudentResult), typeof(StudentTranscriptResultDTO))]
        [InlineData(typeof(Transcript), typeof(StudentTranscriptDTO))]
        public void StudentResultMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(Course), typeof(CourseDTO))]
        [InlineData(typeof(CourseDTO), typeof(Course))]
        public void CourseMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(Course), typeof(FullCourseListingDTO))]
        [InlineData(typeof(Course), typeof(BasicCourseListingDTO))]
        public void CourseListingMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
        [Theory]
        [InlineData(typeof(CourseLevelDTO), typeof(CourseLevel))]
        [InlineData(typeof(CourseLevel), typeof(CourseLevelDTO))]
        public void CourseLevelMap_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);
            _Mapper.Map(instance, origin, destination);
        }
    }

}
