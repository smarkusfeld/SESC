using Microsoft.AspNetCore.Mvc;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace RegistrarService.Api.Controllers
{
    /// <summary>
    /// Controller for all application logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationService _service;

        private readonly ILogger<ApplicationsController> _logger;

        /// <summary>
        /// Application Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public ApplicationsController(IApplicationService service, ILogger<ApplicationsController> logger)
        {

            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// View all applications
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all applications from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the application service returns a null task<br/> 
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Finding Applications Records");
            var result = await _service.GetAllApplications();
            _logger.LogInformation("Returned all applications from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
        /// <summary>
        /// View all applications for course
        /// <br></br>
        /// </summary>
        /// <param name="courseCode"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all applications for coursefrom the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the application service returns a null task<br/> 
        /// </returns>
        [HttpGet("course/{courseCode}")]
        public async Task<IActionResult> GetAllByCourse(string courseCode)
        {
            _logger.LogInformation($"Finding Applications Records for Course {courseCode}");
            var result = await _service.GetAllApplicationsbyCourse(courseCode);
            _logger.LogInformation($"Returned Applications Records for Course {courseCode}");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
        /// <summary>
        /// View all applications by status
        /// <br></br>
        /// </summary>
        /// <param name="status"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all applications by statys from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the application service returns a null task<br/> 
        /// </returns>
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllByStatus(string status)
        {
            _logger.LogInformation($"Finding Applications Records with Status {status}");
            var result = await _service.GetAllApplicationsbyStatus(status);
            _logger.LogInformation($"Returned Applications Records for Course {status}");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }

        /// <summary>
        /// View all applications for applicant
        /// <br></br>
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all applications for applicant from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the application service returns a null task<br/> 
        /// </returns>
        [HttpGet("all/{applicantId}")]
        public async Task<IActionResult> GetAll(int applicantId)
        {
            _logger.LogInformation("Finding Applications Records for Applicant");
            var result = await _service.GetAllApplications(applicantId);
            _logger.LogInformation("Returned Applications Records for Applicant");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }

        /// <summary>
        /// View all applications for applicant
        /// <br></br>
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all applications from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if application was not found <br/> 
        /// </returns>
        [HttpGet("{applicationId}")]
        public async Task<IActionResult> Get(int applicationId)
        {
            _logger.LogInformation($"Finding Application");
            var result = await _service.GetApplication(applicationId);
            _logger.LogInformation($"Returned Application");
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Add Application
        /// <br></br>
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="courseCode"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated application <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("new/{applicantId}/{courseCode}")]
        public async Task<IActionResult> AddApplication(int applicantId, string courseCode)
        {
            _logger.LogInformation($"Adding Application");
            var result = await _service.SaveApplication(applicantId, courseCode);
            _logger.LogInformation($"Returned Updated Application");
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Add Application
        /// <br></br>
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="inputModel"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated application <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("new")]
        public async Task<IActionResult> AddApplication( [FromBody] NewApplicationDTO inputModel)
        {
            _logger.LogInformation($"Adding Application");
            var result = await _service.SaveApplication(inputModel);
            _logger.LogInformation($"Returned Updated Application");
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Update Application
        /// <br></br>
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated application <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("update")]
        public async Task<IActionResult> AddApplication([FromBody] UpdateApplicationDTO inputModel)
        {
            _logger.LogInformation($"Updating Application");
            var result = await _service.UpdateApplication(inputModel);
            _logger.LogInformation($"Returned Updated Application");
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Accept Application
        /// <br></br>
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated application <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("accept/{applicationId}")]
        public async Task<IActionResult> AcceptApplication(int applicationId)
        {
            _logger.LogInformation($"Accepting Application");
            var result = await _service.Accept(applicationId);
            _logger.LogInformation($"Returned Updated Application");
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Decline Application
        /// <br></br>
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated application <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("decline/{applicationId}")]
        public async Task<IActionResult> DeclineApplication(int applicationId)
        {
            _logger.LogInformation($"Declining Application");
            var result = await _service.Decline(applicationId);
            _logger.LogInformation($"Returned Updated Application");
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Withdraw Application
        /// <br></br>
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated application <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("withdraw/{applicationId}")]
        public async Task<IActionResult> WithdrawApplication(int applicationId)
        {
            _logger.LogInformation($"Withdrawing Application");
            var result = await _service.Withdraw(applicationId);
            _logger.LogInformation($"Returned Updated Application");
            return result != null ? Ok(result) : BadRequest();
        }

    }
}
