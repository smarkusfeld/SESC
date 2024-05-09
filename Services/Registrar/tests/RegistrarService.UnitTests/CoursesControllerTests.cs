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
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;

namespace RegistrarService.UnitTests
{
    public class CoursesControllerTests
    {
        private readonly Mock<ICourseService> courseService;
        private readonly Mock<ILogger<CoursesController>> logger;
        public CoursesControllerTests()
        {
            courseService = new Mock<ICourseService>();
            logger = new Mock<ILogger<CoursesController>>();
        }
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            //arrange
            CourseListingDTO courseDTO = new CourseListingDTO
            {
                IsActive = true,
                CourseCode = "8L17-2022",
                ProgrammeCode = "8L17",
                StartDate = new DateTime(2022, 09, 01),
                EnrolmentDeadline = new DateTime(2022, 07, 01),
                ApplicationDeadline = new DateTime(2022, 01, 15)
            };

            courseService.Setup(x => x.GetCourse("8L17-2022"))
                .ReturnsAsync(courseDTO);
            var courseController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await courseController.Get("8L17-2022");
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task Get_ReturnsAccountDTO()
        {
            //arrange
            CourseListingDTO courseDTO = new CourseListingDTO
            {
                IsActive = true,
                CourseCode = "8L17-2022",
                ProgrammeCode = "8L17",
                StartDate = new DateTime(2022, 09, 01),
                EnrolmentDeadline = new DateTime(2022, 07, 01),
                ApplicationDeadline = new DateTime(2022, 01, 15)
            };

            courseService.Setup(x => x.GetCourse("8L17-2022"))
                .ReturnsAsync(courseDTO);
            var courseController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await courseController.Get("8L17-2022");
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<CourseListingDTO>(actionResult.Value);
            Assert.Equal(courseDTO, actionResult.Value);
        }
        [Fact]
        public async Task Get_ReturnsReturnsNotFound()
        {
            //arrange
            courseService.Setup(x => x.GetCourse("8L17-2022"))
                .Returns(Task.FromResult<CourseListingDTO>(null));
            var courseController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await courseController.Get("8L17-2022");
            var actionResult = result as NotFoundResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
       
        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            //arrange
            var courseDTOs = GetCourseDTOList();
            courseService.Setup(x => x.GetAllActiveCourses())
                .ReturnsAsync(courseDTOs);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAll();
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
            IEnumerable<CourseListingDTO> noReccords = null;
            courseService.Setup(x => x.GetAllActiveCourses())
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAll();
            var actionResult = result as NotFoundResult;

            //assert
            Assert.Equal(404, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetAll_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = new List<CourseListingDTO>();
            courseService.Setup(x => x.GetAllActiveCourses())
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAll();
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task GetCourses_ReturnsOkResult()
        {
            //arrange
            var courseDTOs = GetCourseDTOList();
            courseService.Setup(x => x.GetCoursesByProgramme("8L17"))
                .ReturnsAsync(courseDTOs);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetCourses("8L17");
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

        }
        [Fact]
        public async Task GetCourses_TaskResultNullReturnsNotFound()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = null;
            courseService.Setup(x => x.GetCoursesByProgramme("8L17"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetCourses("8L17");
            var actionResult = result as NotFoundResult;

            //assert
            Assert.Equal(404, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetCourses_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = new List<CourseListingDTO>();
            courseService.Setup(x => x.GetCoursesByProgramme("8L17"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetCourses("8L17");
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task GetAllCoursesBySubject_ReturnsOkResult()
        {
            //arrange
            var courseDTOs = GetCourseDTOList();
            courseService.Setup(x => x.SearchCourseBySubject("search"))
                .ReturnsAsync(courseDTOs);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesBySubject("search");
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

        }
        [Fact]
        public async Task GetAllCoursesBySubject_TaskResultNullReturnsNotFound()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = null;
            courseService.Setup(x => x.SearchCourseBySubject("search"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesBySubject("search");
            var actionResult = result as NotFoundResult;

            //assert
            Assert.Equal(404, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetAllCoursesBySubject_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = new List<CourseListingDTO>();
            courseService.Setup(x => x.SearchCourseBySubject("search"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesBySubject("search");
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task GetAllCoursesBySchool_ReturnsOkResult()
        {
            //arrange
            var courseDTOs = GetCourseDTOList();
            courseService.Setup(x => x.SearchCourseBySchool("search"))
                .ReturnsAsync(courseDTOs);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesBySchool("search");
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

        }
        [Fact]
        public async Task GetAllCoursesBySchool_TaskResultNullReturnsNotFound()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = null;
            courseService.Setup(x => x.SearchCourseBySchool("search"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesBySchool("search");
            var actionResult = result as NotFoundResult;

            //assert
            Assert.Equal(404, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetAllCoursesBySchool_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = new List<CourseListingDTO>();
            courseService.Setup(x => x.SearchCourseBySchool("search"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesBySchool("search");
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task GetAllCoursesByName_ReturnsOkResult()
        {
            //arrange
            var courseDTOs = GetCourseDTOList();
            courseService.Setup(x => x.SearchCourseByName("search"))
                .ReturnsAsync(courseDTOs);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesByName("search");
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

        }
        [Fact]
        public async Task GetAllCoursesByName_TaskResultNullReturnsNotFound()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = null;
            courseService.Setup(x => x.SearchCourseByName("search"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesByName("search");
            var actionResult = result as NotFoundResult;

            //assert
            Assert.Equal(404, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetAllCoursesByName_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<CourseListingDTO> noReccords = new List<CourseListingDTO>();
            courseService.Setup(x => x.SearchCourseByName("search"))
                .ReturnsAsync(noReccords);
            var coursesController = new CoursesController(courseService.Object, logger.Object);
            //act
            var result = await coursesController.GetAllCoursesByName("search");
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(actionResult);
        }
        private IEnumerable<CourseListingDTO> GetCourseDTOList()
        {
            IEnumerable<CourseListingDTO> courseDTOList = new List<CourseListingDTO>
            {
                new CourseListingDTO
                {
                   IsActive=true,
                   CourseCode = "8L17-2022",
                   ProgrammeCode = "8L17",
                   StartDate = new DateTime(2022, 09, 01),
                   EnrolmentDeadline = new DateTime(2022, 07, 01),
                   ApplicationDeadline = new DateTime(2022, 01, 15)
                },
                new CourseListingDTO
                {
                    IsActive = true,
                    CourseCode = "8L17-2023",
                    ProgrammeCode = "8L17",
                    StartDate = new DateTime(2023, 09, 01),
                    EnrolmentDeadline = new DateTime(2023, 07, 01),
                    ApplicationDeadline = new DateTime(2023, 01, 15)
                },
                new CourseListingDTO
                {
                    IsActive = true,
                    CourseCode = "8L17-2024",
                    ProgrammeCode = "8L17",
                    StartDate = new DateTime(2024, 09, 01),
                    EnrolmentDeadline = new DateTime(2024, 07, 01),
                    ApplicationDeadline = new DateTime(2024, 01, 15)
                },
            };
            return courseDTOList;
        }
    }
}
