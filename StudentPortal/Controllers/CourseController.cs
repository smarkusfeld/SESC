using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    /// <summary>
    /// Controller for all course logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        //view courses
        private readonly ILogger<Controller> _logger;
        public CourseController(ILogger<CourseController> logger)
        {

            _logger = logger;
        }

    }
}
