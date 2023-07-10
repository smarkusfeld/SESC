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
        private readonly ILogger<CoursesController> _logger;
        public CoursesController(ICourseService service, ILogger<CoursesController> logger)
        {

            _service = service;
            _logger = logger;
        }

    }
}
