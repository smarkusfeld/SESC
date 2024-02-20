using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RegistrarService.Api.Controllers;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Domain.Entities;
using Xunit;

namespace RegistrarService.Tests
{
    public class AccountsControllerTest
    {
        private readonly Mock<IStudentAccountService> accountService;
        private readonly Mock<ILogger<AccountsController>> logger;
        public AccountsControllerTest()
        {
            accountService = new Mock<IStudentAccountService>();
            logger = new Mock<ILogger<AccountsController>>();
        }
        /// <summary>
        /// Test view profile method returns ok result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ViewProfile_ReturnsOkResult()
        {
            //arrange
            var student = GetStudentDetailedDTO();
            accountService.Setup(x => x.GetStudentAccountDetail("c1234567"))
                .ReturnsAsync(student);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.ViewProfile("c1234567");
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        /// <summary>
        /// Test view profile method returns student detailed dto 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ViewProfile_ReturnsStudentDetailedDTO()
        {
            //arrange
            var student = GetStudentDetailedDTO();
            accountService.Setup(x => x.GetStudentAccountDetail("c1234567"))
                .ReturnsAsync(student);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.ViewProfile("c1234567");
            var actionResult = result as ObjectResult;
            
            //assert
            Assert.IsType<UpdateStudentContactDTO>(actionResult.Value);
            Assert.Equal(student, actionResult.Value);
        }
        /// <summary>
        /// Test  view profile returns bad result when account service returns null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ViewProfile_ReturnsBadResult()
        {
            //arrange
            accountService.Setup(x => x.GetStudentAccountDetail("c1234567"))
                .Returns(Task.FromResult<UpdateStudentContactDTO>(null));
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.ViewProfile("c1234567");
            var actionResult = result as BadRequestResult;
            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
        /// <summary>
        /// Test update profile returns Ok result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateProfile_ReturnsOkResult()
        {
            //arrange
            var student = GetStudentDetailedDTO();
            accountService.Setup(x => x.UpdateContactInformation(student))
                .ReturnsAsync(student);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.UpdateProfile(student);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        /// <summary>
        /// Test update profile returns Ok result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateProfile_ReturnsStudentDetailedDTO()
        {
            //arrange
            var student = GetStudentDetailedDTO();
            accountService.Setup(x => x.UpdateContactInformation(student))
                .ReturnsAsync(student);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.UpdateProfile(student);
            var actionResult = result as ObjectResult;

            //assert
            Assert.IsType<UpdateStudentContactDTO>(actionResult.Value);
            Assert.Equal(student, actionResult.Value);
        }
        /// <summary>
        /// Test update profile returns bad result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateProfile_ReturnsBadResult()
        {
            //arrange
            var student = GetStudentDetailedDTO();
            accountService.Setup(x => x.GetStudentAccountDetail("c1234567"))
                .Returns(Task.FromResult<UpdateStudentContactDTO>(null));
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.UpdateProfile(student);
            var actionResult = result as BadRequestResult;
            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
        /// <summary>
        /// Test view transcript returns ok result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ViewTranscript_ReturnsOkResult()
        {
            //arrange
            var transcript= GetStudentTranscriptDTO();
            accountService.Setup(x => x.GetStudentTranscript("c1234567"))
                .ReturnsAsync(transcript);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.ViewTranscript("c1234567");
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        /// <summary>
        /// Test view transcript returns TranscriptDTO
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ViewTranscript_ReturnsTranscriptDTO()
        {
            //arrange
            var transcript = GetStudentTranscriptDTO();
            accountService.Setup(x => x.GetStudentTranscript("c1234567"))
                .ReturnsAsync(transcript);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.ViewTranscript("c1234567");
            var actionResult = result as ObjectResult;

            //assert
            Assert.IsType<StudentTranscriptDTO>(actionResult.Value);
            Assert.Equal(transcript, actionResult.Value);
        }
        /// <summary>
        /// Test view transcript returns bad result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ViewTranscript_ReturnsBadResult()
        {
            //arrange
            var transcript = GetStudentTranscriptDTO();
            accountService.Setup(x => x.GetStudentTranscript("c1234567"))
                .Returns(Task.FromResult<StudentTranscriptDTO>(null));
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.ViewTranscript("c1234567");
            var actionResult = result as BadRequestResult;
            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
        private static StudentTranscriptDTO GetStudentTranscriptDTO()
        {
            return new StudentTranscriptDTO()
            {
                Id= 1,
                StudentId = "c1234567",
                StudentFullName = "Jane M. Doe",
                StudentSurname = "Doe",
                CourseName="Course"

            };
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
    }
}
