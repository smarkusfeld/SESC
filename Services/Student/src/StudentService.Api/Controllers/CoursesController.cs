using Microsoft.AspNetCore.Mvc;
using StudentService.Application.Interfaces.Services;

namespace StudentService.Api.Controllers
{
    /// <summary>
    /// Controller for all course logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;

        private readonly ILogger<CoursesController> _logger;

        /// <summary>
        /// CourseController Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public CoursesController(ICourseService service, ILogger<CoursesController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get All Active Courses
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all active course offerings <br/> 
        /// A 404 status code prodeced by the <seealso cref="NotFoundObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.GetAllCourses();
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Search for Course By Subject
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all active course offerings <br/> 
        /// A 404 status code prodeced by the <seealso cref="NotFoundObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("subject/{search}")]
        public async Task<IActionResult> GetAllCoursesBySubject(string search)
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.SearchCourseBySubject(search);
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Search for Course By Sschool
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all active course offerings <br/> 
        /// A 404 status code prodeced by the <seealso cref="NotFoundObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("school/{search}")]
        public async Task<IActionResult> GetAllCoursesBySchool(string search)
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.SearchCourseBySubject(search);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
