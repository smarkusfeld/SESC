using Microsoft.AspNetCore.Mvc;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;

namespace StudentService.Api.Controllers
{
    
    /// <summary>
    /// Controller for all enrol logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EnrolController : Controller
    {
        private readonly IEnrolService _service;

        private readonly ILogger<EnrolController> _logger;

        /// <summary>
        ///  Registrar Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public EnrolController(IEnrolService service, ILogger<EnrolController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Create a new student account, register a new student for a course, and enrol in the correct course offering for the course
        /// <br></br>
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the registration and and student account details <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if registration can not be completed<br/> 
        /// </returns>
        [HttpGet("register")]
        public async Task<IActionResult> CourseRegistration([FromBody] StudentRegistrationDTO inputModel )
        {
            _logger.LogInformation("registering student");
            var result = await _service.RegisterNewStudent(inputModel);
            return result != null ? Ok(result) : BadRequest(); 
        }

        /// <summary>
        /// Enrol Student in Eligible Course
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseCode"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with enrolment confirmation details <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if enrolment can not be completed<br/> 
        /// </returns>
        [HttpGet("{studentId}/{courseCode}")]
        public async Task<IActionResult> StudentEnrolment(string studentId, string courseCode)
        {
            _logger.LogInformation($"Checking eligibile offerings for course {studentId}");
            var courseId = await _service.GetEligiableCourseOffering(studentId, courseCode);
            _logger.LogInformation("enrolling student");
            var result = await _service.CourseEnrolment(studentId, courseId);
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Get All Student Enrolments
        /// </summary>
        /// <param name="studentId"></param>
        // <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with student enrolment history <br/> 
        /// A 400 status code prodeced by the <seealso cref="NoContentResult"/> if no records exist<br/> 
        /// </returns>
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetAllEnrolments(string studentId)
        {
            var result = await _service.GetAllEnrolments(studentId);
            return result != null ? Ok(result) : NoContent();
        }
    }

    
}
