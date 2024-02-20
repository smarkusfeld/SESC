using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using RegistrarService.Api.Controllers;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Services;
using RegistrarService.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RegistrarService.UnitTests
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
