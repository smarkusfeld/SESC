using StudentPortal.Controllers;

namespace StudentPortal.Services
{
    public class StudentGatewayService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StudentGatewayService> _logger;
        public StudentGatewayService(HttpClient httpClient, ILogger<StudentGatewayService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        //

    }
}
