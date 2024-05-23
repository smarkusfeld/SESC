
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RegistrarService.IntegrationTests
{
    public class CourseControllerIntegrationTests : IClassFixture<TestingApiFactory<Program>>
    {
        private readonly HttpClient _client;

        public CourseControllerIntegrationTests(TestingApiFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsCoursesListingDTO()
        {
            var response = await _client.GetAsync("/Courses");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("8L17-2022", responseString);

        }
    }
}
