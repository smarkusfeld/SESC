using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RegistrarService.IntegrationTests
{
    public class StudentControllerIntegrationTests: IClassFixture<TestingApiFactory<Program>>
    {
        private readonly HttpClient _client;

        public StudentControllerIntegrationTests(TestingApiFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsStudentAccounts()
        {
            var response = await _client.GetAsync("/Students");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            
        }
    }
}
