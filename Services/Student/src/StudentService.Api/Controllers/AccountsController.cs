using Microsoft.AspNetCore.Mvc;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs;
using StudentService.Application.Models.DTOs.InputModels;

namespace StudentService.Api.Controllers
{
    /// <summary>
    /// Controller for all account logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IStudentAccountService _service;

        private readonly ILogger<AccountsController> _logger;

        /// <summary>
        /// AccounrController Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public AccountsController(IStudentAccountService service, ILogger<AccountsController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// View student profile
        /// <br></br>
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="UpdateStudentContactDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> ViewProfile(string studentId)
        {
            _logger.LogInformation("Finding Student Record");
            var result = await _service.GetStudentAccountDetail(studentId);
            return result != null ? Ok(result) : BadRequest();
        }
        /// <summary>
        /// View student transcript
        /// <br></br>
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="StudentTranscriptDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("transcript/{id}")]
        public async Task<IActionResult> ViewTranscript(string studentId)
        {
            _logger.LogInformation("Finding Student Record");
            var result = await _service.GetStudentTranscript(studentId);
            return result != null ? Ok(result) : BadRequest();
        }
        /// <summary>
        /// Update student profile
        /// <br></br>
        /// </summary>
        /// <param name="account"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with updated <seealso cref="UpdateStudentContactDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateStudentContactDTO account)
        {
            _logger.LogInformation("Finding Student Record");
            var result = await _service.UpdateContactInformation(account);
            return result != null ? Ok(result) : BadRequest();
        }       
    }
}
