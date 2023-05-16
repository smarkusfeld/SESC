using Azure;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace FinanceService.Api.Controllers
{
    /// <summary>
    /// Controller for all account logic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all accounts 
        /// </summary>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAccounts();
            return response == null ? NotFound() : Ok(response);
        }
        /// <summary>
        /// Find an account by passing the account id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns><seealso cref="IActionResult"/></returns> 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetAccountById(id);
            return response == null ? BadRequest() : Ok(response);
        }
        /// <summary>
        /// Find an account by passing the student id 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentAccount(string studentId)
        {
            var response = await _service.GetStudentAccount(studentId);
            return response == null ? BadRequest("Account Does Not Exist") : Ok(response);
        }
        /// <summary>
        /// Create a new account by passing the student id
        /// </summary>
        /// <remarks>If the account already exists <seealso cref="StatusCodes.Status400BadRequest"/> is returned</remarks>
        /// <param name="studentId"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPost("{studentid}")]
        public async Task<IActionResult> CreateAccount(string studentid)
        {
            AccountDTO accountDTO = new AccountDTO
            {
                StudentID = studentid,
                HasOutstandingBalance = false,
            };

            var response = await _service.CreateAccount(accountDTO);
            return response == true ? Ok(response) : BadRequest();
        }
        /// <summary>
        /// Delete account by id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAccount(id);
            return response == true ? Ok(response) : BadRequest();
        }
    }
}
