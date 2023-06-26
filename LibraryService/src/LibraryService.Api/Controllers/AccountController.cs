using LibraryService.Application.Models;
using LibraryService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly ILogger<AccountController> _logger;


        public AccountController(IAccountService service, ILogger<AccountController> logger)
        {
           
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accountDtos = await _service.GetAllAccounts();
            _logger.LogInformation($"Returned all accounts from database.");
            return Ok(accountDtos);
        }
        
        
        /// <summary>
        /// New Student Account
        /// </summary>
        /// <returns></returns>
        [HttpPost("register/{studentid}")]
        public async Task<IActionResult> Register(string studentid)
        {
            var result = await _service.CreateAccount(studentid,"student");
            _logger.LogInformation($"New account created for student {studentid}");
            return Ok(result);

        }

        /// <summary>
        /// Update Account Pin
        /// </summary>
        /// <param name="accountPinDTO"></param>
        /// <returns></returns>
        [HttpPut("firstlogin")]
        public async Task<IActionResult> Update([FromBody] UpdatePinDTO accountPinDTO)
        {
            
            var result = await _service.UpdateAccountPin(accountPinDTO.AccountId, accountPinDTO.OldPin, accountPinDTO.NewPin);
            _logger.LogInformation($"Pin Updated for {accountPinDTO.AccountId}");
            return Ok(result);

        }

    }
}
