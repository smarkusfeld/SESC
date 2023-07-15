using StudentPortal.Controllers;

namespace StudentPortal.Services
{
    public class GatewayService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GatewayService> _logger;
        public GatewayService(HttpClient httpClient, ILogger<GatewayService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        //

    }
}
