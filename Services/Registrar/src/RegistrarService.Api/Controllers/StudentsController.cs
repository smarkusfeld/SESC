using Microsoft.AspNetCore.Mvc;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;

namespace RegistrarService.Api.Controllers
{
    /// <summary>
    /// Controller for all account logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        private readonly ILogger<StudentsController> _logger;

        /// <summary>
        /// AccounrController Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public StudentsController(IStudentService service, ILogger<StudentsController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// View student account
        /// <br></br>
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="StudentAccountDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="NotFoundResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("{studentId}")]
        public async Task<IActionResult> Get(int studentId)
        {
            _logger.LogInformation("Finding Student Record");
            var result = await _service.GetStudentAccount(studentId);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// View all students
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all accounts from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the student service returns a null task<br/> 
        /// </returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Finding Student Records");
            var result = await _service.GetStudentAccounts();
            _logger.LogInformation("Returned all students from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }
        /// <summary>
        /// View student results
        /// <br></br>
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="StudentAccountDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="NotFoundResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("results/{studentId}")]
        public async Task<IActionResult> GetResults(int studentId)
        {
            _logger.LogInformation("Finding Student Record");
            var result = await _service.GetProgressionResults(studentId);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Update student account
        /// <br></br>
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="inputModel"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="StudentAccountDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if update fails<br/> 
        /// </returns>
        [HttpPost("{studentId}/update")]
        public async Task<IActionResult> Update(int studentId, [FromBody] UpdateStudentDTO inputModel)
        {
            _logger.LogInformation("Updating Student Record");
            var result = await _service.UpdateStudentAccount(studentId, inputModel);
            return result != null ? Ok(result) : BadRequest();
        }

    }
}
