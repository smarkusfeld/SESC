using Microsoft.AspNetCore.Mvc;
using RegistrarService.Application.Interfaces.Services;

namespace RegistrarService.Api.Controllers
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
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the course service returns a null task<br/> 
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.GetAllActiveCourses();
            _logger.LogInformation("Returned Courses from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
        /// <summary>
        /// Get Course by Course Code
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with course <br/> 
        /// A 400 status code prodeced by the <seealso cref="NotFoundResult"/> if course was not found<br/>
        /// </returns>
        [HttpGet("{courseCode}")]
        public async Task<IActionResult> Get(string courseCode)
        {
            _logger.LogInformation($"Finding Course {courseCode}");
            var result = await _service.GetCourse(courseCode);
            return result != null ? Ok(result) : NotFound();
        }
        /// <summary>
        /// Get Courses by Program Code
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with courses <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the course service returns a null task<br/> 
        /// </returns>
        [HttpGet("{programmeCode}")]
        public async Task<IActionResult> GetCourses(string programmeCode)
        {
            _logger.LogInformation($"Finding Courses for Programme Code {programmeCode}");
            var result = await _service.GetCoursesByProgramme(programmeCode);
            _logger.LogInformation("Returned Courses from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
        /// <summary>
        /// Search for Course By Subject
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with course search results <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the course service returns a null task<br/> 
        /// </returns>
        [HttpGet("subject/{search}")]
        public async Task<IActionResult> GetAllCoursesBySubject(string search)
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.SearchCourseBySubject(search);
            _logger.LogInformation("Returned Courses from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
        /// <summary>
        /// Search for Course By School
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with course search results <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the course service returns a null task<br/> 
        /// </returns>
        [HttpGet("school/{search}")]
        public async Task<IActionResult> GetAllCoursesBySchool(string search)
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.SearchCourseBySchool(search);
            _logger.LogInformation("Returned Courses from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Search for Course By Programme Name
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with course search results <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the course service returns a null task<br/> 
        /// </returns>
        [HttpGet("name/{search}")]
        public async Task<IActionResult> GetAllCoursesByName(string search)
        {
            _logger.LogInformation("Finding Courses");
            var result = await _service.SearchCourseByName(search);
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }

    }
}
