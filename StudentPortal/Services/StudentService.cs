using StudentPortal.Controllers;

namespace StudentPortal.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StudentService> _logger;
        public StudentService(HttpClient httpClient, ILogger<StudentService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        //

    }
}
