using Microsoft.AspNetCore.Mvc;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Api.Controllers
{
    
    /// <summary>
    /// Controller for all enrol logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EnrolmentsController : Controller
    {
        private readonly IEnrolService _service;

        private readonly ILogger<EnrolmentsController> _logger;

        /// <summary>
        ///  Registrar Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public EnrolmentsController(IEnrolService service, ILogger<EnrolmentsController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Create a new student account, register a new student for a course, and enrol in the correct course offering for the course
        /// <br></br>
        /// </summary>
        /// <param name="courseCode"></param>
        /// <param name="applicantId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the registration and and student account details <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if registration can not be completed<br/> 
        /// </returns>
        [HttpPost("first/{applicantId}/{courseCode}")]
        public async Task<IActionResult> FirstEnrolment(string courseCode, int applicantId)
        {
            _logger.LogInformation("Creating student account and enrolling student");
            var result = await _service.FirstEnrol(courseCode, applicantId);
            return result != null ? Ok(result) : BadRequest(); 
        }

        /// <summary>
        /// Enrol Student in Eligible Course
        /// </summary>
        /// <param name="courseCode"></param>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with enrolment confirmation details <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if enrolment can not be completed<br/> 
        /// </returns>
        [HttpPost("{studentId}/{courseCode}")]
        public async Task<IActionResult> StudentEnrolment(string courseCode, int studentId)
        {
            _logger.LogInformation("Enrolling Student");
            var result = await _service.Enrol(courseCode, studentId);
            return result != null ? Ok(result) : BadRequest();
        }

        

        /// <summary>
        /// Get All Student Enrolments
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with student enrolment history <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the course service returns a null task<br/> 
        /// </returns>
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetAllEnrolments(int studentId)
        {
            _logger.LogInformation("Finding Enrolments");
            var result = await _service.GetAllEnrolments(studentId);
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
    }

    
}
