using Azure;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using FinanceService.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService service, ILogger<AccountController> logger)
        {
            _service= service;
            _logger = logger;
        }

     

        /// <summary>
        /// Get all accounts 
        /// </summary>
        /// <returns>A collection of accounts or bad request response</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAccounts();
            int count = response.Count();
            return count == 0 ? BadRequest("No Records Found") : Ok(response);

        } 
        ///// <summary>
        ///// Find an account by passing the account id
        ///// </summary>
        ///// <param name="id">account id</param>
        ///// <returns><seealso cref="IActionResult"/></returns> 
        //[HttpGet("id/{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var response = await _service.GetAccountById(id);
        //        return response == null ? NotFound() : Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Something went wrong inside the Get action: " + ex);
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
        /// <summary>
        /// Find an account by passing the student id 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentAccount(string studentId)
        {
            try
            {
                var response = await _service.GetStudentAccount(studentId);
                return response == null ? BadRequest("Account Does Not Exist") : Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the GetStudentAccount action: " + ex);
                return StatusCode(500, "Internal server error");
            }
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
            if(studentid == null)
            {
                return BadRequest();
            }
            var check = await _service.StudentAccountExists(studentid);
            if (check)
            {
                return BadRequest("Account Already Associated with student id: " + studentid);
            }
                                             
            try
            {
                var response = await _service.CreateAccount(studentid);
                return response == true
                ? Ok("Finaance Account Created for Student: " + studentid)
                : BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the CreateAccount action: " + ex);
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Delete account by id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.DeleteAccount(id);
                return response == true ? Ok("Account Deleted") : BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the Delete account action: " + ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
