using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

    }
}
