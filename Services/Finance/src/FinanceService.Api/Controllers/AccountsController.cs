using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Api.Controllers
{
    /// <summary>
    /// Controller for all account logic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;
        private readonly ILogger<AccountsController> _logger;

        /// <summary>
        /// Account Controller Constructor. 
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
        /// Get All Accounts
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all accounts from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the account service returns a null task
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            _logger.LogInformation("Getting all accounts from database.");
            var accountDtos = await _service.GetAllAccounts();
            _logger.LogInformation("Returned all accounts from database.");
            if (accountDtos == null) { return NotFound(); }
            return accountDtos.Any() ? Ok(accountDtos) : NoContent();
        }

        /// <summary>
        /// Find Account by Student Id
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the account <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if no account was found
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> QueryAccount(string id)
        {
            _logger.LogInformation("Searching for account in database.");
            var accountDTO = await _service.GetStudentAccount(id);
            _logger.LogInformation("Returned account seach results");
            return accountDTO == null ? NotFound() : Ok(accountDTO);
        }

        /// <summary>
        /// Create student Account
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> if account was created <br/> 
        /// A 400 status code produced by the <seealso cref="BadRequestResult"/> if account was created <br/> 
        /// </returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id)
        {
            _logger.LogInformation("Creating student account",id);
            var result = await _service.CreateAccount(id);
            return result ? Ok("Account Created") : BadRequest();
        }

        
    }
}
