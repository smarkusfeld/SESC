using Microsoft.AspNetCore.Mvc;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Models.DTOs.InputModels;
using RegistrarService.Application.Models.DTOs.ReponseModels;

namespace RegistrarService.Api.Controllers
{
    /// <summary>
    /// Controller for all applicant logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ApplicantsController : Controller
    {
        private readonly IApplicantService _service;

        private readonly ILogger<ApplicantsController> _logger;

        /// <summary>
        ///  Registrar Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public ApplicantsController(IApplicantService service, ILogger<ApplicantsController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Create new applicant account
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with with <seealso cref="ApplicantDTO"/>  <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if application could not be created<br/> 
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NewApplicantDTO inputModel)
        {
            _logger.LogInformation($"Creating Account");           
            var result = await _service.AddApplicant(inputModel);
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Update applicant account
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="ApplicantDTO"/>  <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if applicant could not be updated<br/> 
        /// </returns>
        [HttpPost("{applicantId}")]
        public async Task<IActionResult> Update([FromBody] UpdateApplicantDTO inputModel)
        {
            _logger.LogInformation($"Updating Applicant");
            var result = await _service.UpdateApplicant(inputModel);
            return result != null ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// View all applicants
        /// <br></br>
        /// </summary>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all accounts from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the applicant service returns a null task<br/> 
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Finding Applicant Records");
            var result = await _service.GetAllApplicants();
            _logger.LogInformation("Returned all applicants from database.");
            if (result == null) { return NotFound(); }
            return result.Any() ? Ok(result) : NoContent();
        }

        /// <summary>
        /// View applicant
        /// <br></br>
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="ApplicantDTO"/>  <br/> 
        /// A 400 status code prodeced by the <seealso cref="NotFoundResult"/> if student was not found<br/> 
        /// </returns>
        [HttpGet("{applicantId}")]
        public async Task<IActionResult> Get(int applicantId)
        {
            _logger.LogInformation("Finding Applicant Record");
            var result = await _service.GetApplicant(applicantId);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
