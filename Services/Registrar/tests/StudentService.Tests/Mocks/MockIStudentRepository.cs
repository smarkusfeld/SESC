using Moq;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.UnitTests.Mocks
{
    internal class MockIStudentRepository
    {
        public static Mock<IStudentRepository> GetMock()
        {
            var mock = new Mock<IStudentRepository>();
            Course course = new()
            {
                Id = 1,
                CourseCode = "test"
            };
            var students = new List<Student>()
            {
                new Student()
                {
                    AccountNumber = 1234567,
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
                        },
                    },
                     Transcript = new Transcript("c1234567",course),
                     Registrations = new List<CourseRegistration>(),
                     Enrolments = new List<Enrolment>(),
                },
                 new Student()
                {
                    AccountNumber = 7654321,
                    StudentId = "c7654321",
                    FirstName = "John",
                    MiddleName = "P.",
                    Surname = "Doe",
                    ContactDetail = new()
                    {
                        StudentEmail = "JohnDoe@student.school.edu",
                        AlternateEmail = "JohnDoe@email.com",
                        PhoneNumber = "07745 5874695",
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
                        },
                    },
                     Transcript = new Transcript("c7654321",course),
                     Registrations = new List<CourseRegistration>(),
                     Enrolments = new List<Enrolment>(),
                }
            };


            // Set up
            mock.Setup(m => m.GetAsync(It.IsAny<string>()))
                .Returns((string id) => students.Where(x => x.StudentId == id).ToList());

            mock.Setup(m => m.GetTranscriptAsync(It.IsAny<string>()))
                .Returns((string id) => students.Select(x=>x.Transcript).Where(x => x.StudentId == id).ToList());
            //update student account
            mock.Setup(m => m.UpdateAsync(It.IsAny<Student>()))
                .Returns((Student student) => students
                                                .Where(x => x.StudentId == student.StudentId)
                                                .Select(x=> x = student));
            return mock;
        }
    }
}
