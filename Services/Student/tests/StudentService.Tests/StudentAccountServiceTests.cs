using AutoMapper;
using Moq;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Application.Services;
using StudentService.Domain.Entities;
using StudentService.UnitTests.Mocks;
using Xunit;

namespace StudentService.Tests
{
    public class StudentAccountServiceTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IUnitOfWork> unitOfWork;
        public StudentAccountServiceTests()
        {

            unitOfWork = new Mock<IUnitOfWork>();
            mapper = new MappingTests().Mapper;
        }
        
        /// <summary>
        /// Test Get Student Account Returns Student DTO
        /// </summary>
        [Fact]
        public void GetStudentAccount_ReturnsStudentDTO()
        {
            //arrange
            var student = new Student
            {
                StudentId = "c1234567",
                FirstName = "Jane",
                MiddleName = "M.",
                Surname = "Doe",
            };
            unitOfWork.Setup(x => x.Students.GetAsync("c1234567"))
                .ReturnsAsync(student);
            var service = new StudentAccountService(unitOfWork.Object, mapper);
            //act
            var result = service.GetStudentAccount("c1234567");
            var resultAccount = result.Result;
            //assert
            Assert.NotNull(result);
            Assert.IsType<StudentDTO>(resultAccount);
            Assert.Equal(student.StudentId, resultAccount.StudentId);
            Assert.Equal(student.FirstName, resultAccount.FirstName);
            Assert.Equal(student.MiddleName, resultAccount.MiddleName);
            Assert.Equal(student.Surname, resultAccount.Surname);
        }
        /// <summary>
        /// Test Get Student Account Returns Key Not Found
        /// </summary>
        [Fact]
        public void GetStudentAccount_KeyNotFound()
        {
            //arrange
            unitOfWork.Setup(x => x.Students.GetAsync("c1234567"))
                 .Returns(Task.FromResult<Student>(null));
            var service = new StudentAccountService(unitOfWork.Object, mapper);
            //act
            Assert.ThrowsAsync<KeyNotFoundException>(()=>service.GetStudentAccount("c1234567"));
            
        }
        /// <summary>
        /// Test Get Student Detailed Account Returns Student Detailed DTO
        /// </summary>
        [Fact]
        public void GetStudentAccountDetail_ReturnsStudentDetailedDTO()
        {
            //arrange
            var student = new Student
            {
                StudentId = "c1234567",
                FirstName = "Jane",
                MiddleName = "M.",
                Surname = "Doe",
            };
            unitOfWork.Setup(x => x.Students.GetAsync("c1234567"))
                .ReturnsAsync(student);
            var service = new StudentAccountService(unitOfWork.Object, mapper);
            //act
            var result = service.GetStudentAccountDetail("c1234567");
            var resultAccount = result.Result;
            //assert
            Assert.NotNull(result);
            Assert.IsType<UpdateStudentContactDTO>(resultAccount);
            Assert.Equal(student.StudentId, resultAccount.StudentId);
            Assert.Equal(student.FirstName, resultAccount.FirstName);
            Assert.Equal(student.MiddleName, resultAccount.MiddleName);
            Assert.Equal(student.Surname, resultAccount.Surname);
        }
        /// <summary>
        /// Test Get Student Detailed Account Returns Key Not Found
        /// </summary>
        [Fact]
        public void GetStudentDetailedAccount_KeyNotFound()
        {
            //arrange
            unitOfWork.Setup(x => x.Students.GetAsync("c1234567"))
                 .Returns(Task.FromResult<Student>(null));
            var service = new StudentAccountService(unitOfWork.Object, mapper);
            //act
            Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetStudentAccount("c1234567"));

        }
        /// <summary>
        /// Test Get Student Transcript returns StudentTranscriptDTO
        /// </summary>
        [Fact]
        public void GetStudentTranscript_StudentTranscriptDTO()
        {
            //arrange
            var student = new Student
            {
                StudentId = "c1234567",
                FirstName = "Jane",
                MiddleName = "M.",
                Surname = "Doe",
            };
            var course = new Course
            {
                Id = 1,
                CourseCode = "test"
            };
            var transcript = new Transcript(student, course);
            unitOfWork.Setup(x => x.Students.GetTranscriptAsync("c1234567"))
                 .ReturnsAsync(transcript);
            var service = new StudentAccountService(unitOfWork.Object, mapper);
            //act
            var result =  service.GetStudentTranscript("c1234567");
            var resultAccount = result.Result;
            //assert
            Assert.NotNull(result);
            Assert.IsType<StudentTranscriptDTO>(resultAccount);
            Assert.Equal(transcript.StudentId, resultAccount.StudentId);
            Assert.Equal(student.Surname, resultAccount.StudentSurname);
            Assert.Equal(student.FullName, resultAccount.StudentFullName);
            Assert.Equal(course.Name, resultAccount.CourseName);

        }
        /// <summary>
        /// Test Get Student Transcript returns Key Not Found
        /// </summary>
        [Fact]
        public void GetStudentTranscript_KeyNotFoundException()
        {
            //arrange            
            unitOfWork.Setup(x => x.Students.GetTranscriptAsync("c1234567"))
                  .Returns(Task.FromResult<Transcript>(null));
            var service = new StudentAccountService(unitOfWork.Object, mapper);
            //act
            Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetStudentTranscript("c1234567"));

        }
        /// <summary>
        /// Test Update Contact Information returns Student Detailed DTO
        /// </summary>
        [Fact]
        public void UpdateContactInformation_ReturnsStudentDetailedDTO()
        {

            //arrange
            var uowMock = MockUnitOfWork.GetMock();
            var service = new StudentAccountService(uowMock.Object, mapper);
            var studentDetail = GetStudentDetailedDTO();
            //var student = GetStudents().Where(x=>x.StudentId == studentDetail.StudentId).Single();
            //unitOfWork.Setup(x => x.Save())
            //    .Callback(() => { return; });
            //unitOfWork.Setup(x => x.Students.UpdateAsync(student))
            //     .ReturnsAsync(student);
            
            
            //act
            var result = service.UpdateContactInformation(studentDetail);
            var resultAccount = result.Result;
            //assert
            Assert.NotNull(result);
            Assert.IsType<UpdateStudentContactDTO>(resultAccount);
            Assert.Equal(studentDetail.StudentId, resultAccount.StudentId);
            Assert.Equal(studentDetail.Surname, resultAccount.Surname);
            Assert.Equal(studentDetail.FullName, resultAccount.FullName);
            Assert.Equal(studentDetail.StudentEmail, resultAccount.StudentEmail);
        }

        private static UpdateStudentContactDTO GetStudentDetailedDTO()
        {
           return new UpdateStudentContactDTO()
           {
                StudentId = "c1234567",
                FirstName = "Jane",
                MiddleName = "M.",
                Surname = "Doe",
                StudentEmail = "JaneDoe@student.school.edu",
                AlternateEmail = "JaneDoe@email.com",
                PhoneNumber = "07745 125496",
                TermAddressLineOne = "LineOne",
                TermAddressLineTwo = "LineTwo",
                TermAddressLineThree = "LineThree",
                TermAddressTown_City = "City",
                TermAddressCounty_Region = "Region",
                TermAddressPostCode = "County",
                TermAddressCountry = "Country",
                PermanentAddressLineOne = "LineOne",
                PermanentAddressLineTwo = "LineTwo",
                PermanentAddressLineThree = "LineThree",
                PermanentAddressTown_City = "City",
                PermanentAddressCounty_Region = "Region",
                PermanentAddressPostCode = "County",
                PermanentAddressCountry = "Country",

            };
        }
        private static IEnumerable<Student> GetStudents()
        {
            Course course = new()
            {
                Id = 1,
                CourseCode = "test"
            };
            return new List<Student>()
            {
                new Student()
                {
                    StudentId = "c1234567",
                    FirstName = "Jane",
                    MiddleName = "M.",
                    Surname = "Doe",
                    ContactDetail = new()
                    {
                        StudentEmail = "JaneDoe@student.school.edu",
                        AlternateEmail = "JaneDoe@email.com",
                        PhoneNumber = "07745 125496",
                        TermAddress = new()
                        {
                            LineOne = "LineOne",
                            LineTwo = "LineTwo",
                            LineThree = "LineThree",
                            Town_City = "City",
                            County_Region = "Region",
                            PostCode = "County",
                            Country = "Country"
                        },
                        PermanentAddress = new()
                        {
                            LineOne = "LineOne",
                            LineTwo = "LineTwo",
                            LineThree = "LineThree",
                            Town_City = "City",
                            County_Region = "Region",
                            PostCode = "County",
                            Country = "Country"
                        }
                     },
                     Transcript = new Transcript("c1234567",course),
                     Registrations = new List<CourseRegistration>(),
                     Enrolments = new List<Enrolment>(),
            }};
        }
    }
}
