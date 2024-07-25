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
using RegistrarService.Application.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using RegistrarService.Application.Models.DTOs.InputModels;

namespace RegistrarService.UnitTests
{
    public class EnrolControllerTests
    {
        private readonly Mock<IEnrolService> enrolService;
        private readonly Mock<ILogger<EnrolmentsController>> logger;
        public EnrolControllerTests()
        {
            enrolService = new Mock<IEnrolService>();
            logger = new Mock<ILogger<EnrolmentsController>>();
        }

        [Fact]
        public async Task FirstEnrolment_NullReturnsBadRequest()
        {
            //arrange
            var inputModel = new NewStudentDTO();
            EnrolmentDTO enrolmentDTO = null;
            enrolService.Setup(x => x.Enrol(123, inputModel))
                .ReturnsAsync(enrolmentDTO);
            var enrolController = new EnrolmentsController(enrolService.Object, logger.Object);
            //act
            var result = await enrolController.FirstEnrolment("cc", inputModel);
            var actionResult = result as BadRequestResult;
            //assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task StudentEnrolment_NullReturnsBadRequest()
        {
            //arrange
            var inputModel = new UpdateStudentDTO();
            EnrolmentDTO enrolmentDTO = null;
            enrolService.Setup(x => x.Enrol(123, inputModel))
                .ReturnsAsync(enrolmentDTO);
            var enrolController = new EnrolmentsController(enrolService.Object, logger.Object);
            //act
            var result = await enrolController.StudentEnrolment("cc",12356, inputModel);
            var actionResult = result as BadRequestResult;
            //assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task GetAllEnrolments_ReturnsOKResult()
        {
            //arrange
            var enrolmentDTOs = GetEnrolmentDTOList();
            enrolService.Setup(x => x.GetAllEnrolments(1234567))
                .ReturnsAsync(enrolmentDTOs);
            var enrolController = new EnrolmentsController(enrolService.Object, logger.Object);
            //act
            var result = await enrolController.GetAllEnrolments(1234567);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task GetAllEnrolments_ReturnsEnrolmentDTOs()
        {
            //arrange
            var enrolmentDTOs = GetEnrolmentDTOList();
            enrolService.Setup(x => x.GetAllEnrolments(1234567))
                .ReturnsAsync(enrolmentDTOs);
            var enrolController = new EnrolmentsController(enrolService.Object, logger.Object);
            //act
            var result = await enrolController.GetAllEnrolments(1234567);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.IsType<List<EnrolmentDTO>>(actionResult.Value);
            Assert.Equal(enrolmentDTOs, actionResult.Value);
        }
        [Fact]
        public async Task GeAllEnrolments_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<EnrolmentDTO> noReccords = new List<EnrolmentDTO>(); 
            enrolService.Setup(x => x.GetAllEnrolments(1234567))
                .ReturnsAsync(noReccords);
            var enrolController = new EnrolmentsController(enrolService.Object, logger.Object);
            //act
            var result = await enrolController.GetAllEnrolments(1234567);
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task GetResults_ReturnsNotFound()
        {
            //arrange
            IEnumerable<EnrolmentDTO> noReccords = null;
            enrolService.Setup(x => x.GetAllEnrolments(1234567))
                .ReturnsAsync(noReccords);
            var enrolController = new EnrolmentsController(enrolService.Object, logger.Object);
            //act
            var result = await enrolController.GetAllEnrolments(1234567);
            var actionResult = result as NotFoundResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        
        private IEnumerable<EnrolmentDTO> GetEnrolmentDTOList()
        {
            IEnumerable<EnrolmentDTO> studentDTOList = new List<EnrolmentDTO>
            {
                new EnrolmentDTO
                {
                    StudentId=1234567,


                },
                 new EnrolmentDTO
                {
                    StudentId=765321
                },
                 new EnrolmentDTO
                {
                    StudentId=1122334
                },
            };
            return studentDTOList;
        }
    }
}
