using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RegistrarService.IntegrationTests
{
    public class AccountsControllerIntegrationTests: IClassFixture<TestingApiFactory<Program>>
    {
        private readonly HttpClient _client;

        public AccountsControllerIntegrationTests(TestingApiFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task ViewProfile_WhenCalled_ReturnsDetailedStudentDTO()
        {
            
        }
    }
}
