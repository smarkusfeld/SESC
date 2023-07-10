using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using StudentService.Api.Controllers;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Services;
using StudentService.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentService.UnitTests
{
    public class EnrolControllerTest
    {
        private readonly Mock<IEnrolService> accountService;
        private readonly Mock<ILogger<EnrolController>> logger;
        public EnrolControllerTest()
        {
            accountService = new Mock<IEnrolService>();
            logger = new Mock<ILogger<EnrolController>>();
        }

        /// <summary>
        /// Test course registration returns okay result
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CourseRegistration_ReturnsOkResult()
        {
            
        }
    }
}
