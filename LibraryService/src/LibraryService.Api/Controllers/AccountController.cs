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

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllStudentAccounts();
            int count = response.Count();
            return count == 0 ? BadRequest("No Records Found") : Ok(response);
        }
        /// <summary>
        /// New Student Account
        /// </summary>
        /// <returns></returns>
        [HttpPost("{studentid}")]
       
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
