using Microsoft.AspNetCore.Mvc;
using StudentService.Application.Interfaces.Services;
using StudentService.Application.Models.DTOs.InputModels;
using StudentService.Application.Models.DTOs.ReponseModels;

namespace StudentService.Api.Controllers
{
    /// <summary>
    /// Controller for all account logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;

        private readonly ILogger<AccountsController> _logger;

        /// <summary>
        /// AccounrController Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public AccountsController(IAccountService service, ILogger<AccountsController> logger)
        {

            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Create new student account
        /// <br></br>
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="UpdateStudentContactDTO"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> AddAccount(string studentId)
        {
            _logger.LogInformation("Finding Student Record");
            var result = await _service.C;
            return result != null ? Ok(result) : BadRequest();
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
            var result = await _service.GetStudentAccount(studentId);
            return result != null ? Ok(result) : BadRequest();
        }
            
    }
}
