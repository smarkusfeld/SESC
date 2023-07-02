using LibraryService.Application.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryService.Application.Interfaces.Services;
using Azure;

namespace LibraryService.Api.Controllers
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
        /// 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all accounts from database.");
            var accountDtos = await _service.GetAllAccounts();
            _logger.LogInformation("Returned all accounts from database.");
            if ( accountDtos == null ) { return NotFound(); }
            return accountDtos.Any() ? Ok( accountDtos ) : NoContent() ;
        }
        /// <summary>
        /// Get user borrowing history
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all accounts from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the account service returns a null task
        /// </returns>
        /// 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanHistory(string id)
        {
            _logger.LogInformation("Getting account history from database.");
            var accountHistory = await _service.GetLoanHistory(id);
            _logger.LogInformation("Returned account history  from database.");
            if (accountHistory == null) { return NotFound(); }
            return accountHistory.Any() ? Ok(accountHistory) : NoContent();
        }

        /// <summary>
        /// New Student Account
        /// </summary>
        /// <returns> 
        /// A 201 status code produced by the <seealso cref="CreatedAtActionResult"/> the new account <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if the account was not created<br/> 
        /// </returns>        
        [HttpPost("register/{studentid}")]        
        public async Task<IActionResult> Register(string studentid)
        {
            _logger.LogInformation("Creating student account", studentid);
            var result = await _service.CreateAccount(studentid, "student");
            _logger.LogInformation("Create account complete", result);
            return result != null
                ? CreatedAtAction(nameof(Register), result)
                : BadRequest();
                 


        }

        /// <summary>
        /// Update Account Pin
        /// </summary>
        /// <param name="accountPinDTO"></param>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkResult"/> if the account was updated successfully<br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if the account could not be updated<br/> 
        /// </returns>     
        [HttpPut("reset")]
        public async Task<IActionResult> Update([FromBody] UpdatePinDTO accountPinDTO)
        {
            _logger.LogInformation("Updating Account Pin", accountPinDTO.AccountId);
            var result = await _service.UpdateAccountPin(accountPinDTO.AccountId, accountPinDTO.OldPin, accountPinDTO.NewPin);
            _logger.LogInformation("Update pin complete", result);
            return result? Ok() : BadRequest();

        }

    }
}
