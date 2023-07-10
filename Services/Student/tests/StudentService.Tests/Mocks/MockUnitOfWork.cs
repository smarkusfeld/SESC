using Moq;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.UnitTests.Mocks
{
    internal class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();

            var studentRepoMock = MockIStudentRepository.GetMock();
            // Setup the mock
            mock.Setup(m => m.Courses).Returns(() => new Mock<ICourseRepository>().Object);
            mock.Setup(m => m.Students).Returns(() => studentRepoMock.Object);
            mock.Setup(m => m.Save()).Returns(() => 1);
            return mock;
        }
    }
}
