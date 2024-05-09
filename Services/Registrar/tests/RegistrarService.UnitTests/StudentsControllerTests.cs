using Moq;
using RegistrarService.Application.Interfaces;
using RegistrarService.Api.Controllers;
using RegistrarService.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using AutoMapper.Execution;
using AutoMapper.Internal;
using Xunit;
using Microsoft.Extensions.Logging;
using NLog;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.ReponseModels;
using Microsoft.AspNetCore.Http;

namespace RegistrarService.UnitTests
{
    public class StudentsControllerTests
    {
        private readonly Mock<IStudentService> studentService;
        private readonly Mock<ILogger<StudentsController>> logger;
        public StudentsControllerTests()
        {
            studentService = new Mock<IStudentService>();
            logger = new Mock<ILogger<StudentsController>>();
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            //arrange
            var studentDTOs = GetStudentDTOList();
            studentService.Setup(x => x.GetStudentAccounts())
                .ReturnsAsync(studentDTOs);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

        }
        [Fact]
        public async Task GetAll_TaskResultNullReturnsNotFound()
        {
            //arrange
            IEnumerable<StudentAccountDTO> noReccords = null;
            studentService.Setup(x => x.GetStudentAccounts())
                .ReturnsAsync(noReccords);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetAll();
            var actionResult = result as NotFoundResult;

            //assert
            Assert.Equal(404, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetAll_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<StudentAccountDTO> noReccords = new List<StudentAccountDTO>();
            studentService.Setup(x => x.GetStudentAccounts())
                .ReturnsAsync(noReccords);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetAll();
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }

        
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            //arrange
            StudentAccountDTO accountDTO = new StudentAccountDTO
            {
               
                StudentId = 1234567
            };

            studentService.Setup(x => x.GetStudentAccount(1234567))
                .ReturnsAsync(accountDTO);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.Get(1234567);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task Get_ReturnsAccountDTO()
        {
            //arrange
            StudentAccountDTO accountDTO = new StudentAccountDTO
            {

                StudentId = 1234567
            };

            studentService.Setup(x => x.GetStudentAccount(1234567))
                .ReturnsAsync(accountDTO);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.Get(1234567);
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<StudentAccountDTO>(actionResult.Value);
            Assert.Equal(accountDTO, actionResult.Value);
        }
        [Fact]
        public async Task Get_ReturnsReturnsNotFound()
        {
            //arrange
            studentService.Setup(x => x.GetStudentAccount(1234567))
                .Returns(Task.FromResult<StudentAccountDTO>(null));
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.Get(1234567);
            var actionResult = result as NotFoundResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetStudentAccount_ReturnsOkResult()
        {
            //arrange
            StudentAccountDTO accountDTO = new StudentAccountDTO
            {

                StudentId = 1234567
            };

            studentService.Setup(x => x.GetStudentAccount(1234567))
                .ReturnsAsync(accountDTO);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.Get(1234567);
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task GetResults_ReturnsOKResult()
        {
            //arrange
            StudentProgressionDTO accountDTO = new StudentProgressionDTO
            {

                StudentId = 1234567
            };

            studentService.Setup(x => x.GetProgressionResults(1234567))
                .ReturnsAsync(accountDTO);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetResults(1234567);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task GetResults_ReturnsStudentProgressionDTO()
        {
            //arrange
            StudentProgressionDTO accountDTO = new StudentProgressionDTO
            {

                StudentId = 1234567
            };

            studentService.Setup(x => x.GetProgressionResults(1234567))
                .ReturnsAsync(accountDTO);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetResults(1234567);
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<StudentProgressionDTO>(actionResult.Value);
            Assert.Equal(accountDTO, actionResult.Value);
        }
        [Fact]
        public async Task GetResults_ReturnsNotFound()
        {
            //arrange
            studentService.Setup(x => x.GetProgressionResults(1234567))
                .Returns(Task.FromResult<StudentProgressionDTO>(null));
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetResults(1234567);
            var actionResult = result as NotFoundResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetResults_ReturnsOkResult()
        {
            StudentProgressionDTO accountDTO = new StudentProgressionDTO
            {

                StudentId = 1234567
            };

            studentService.Setup(x => x.GetProgressionResults(1234567))
                .ReturnsAsync(accountDTO);
            var studentController = new StudentsController(studentService.Object, logger.Object);
            //act
            var result = await studentController.GetResults(1234567);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }

        private IEnumerable<StudentAccountDTO> GetStudentDTOList()
        {
            IEnumerable<StudentAccountDTO> studentDTOList = new List<StudentAccountDTO>
            {
                new StudentAccountDTO
                {
                    StudentId=1234567,
                

                },
                 new StudentAccountDTO
                {
                    StudentId=765321
                },
                 new StudentAccountDTO
                {               
                    StudentId=1122334
                },
            };
            return studentDTOList;
        }
       
    }
}