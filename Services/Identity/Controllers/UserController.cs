using IdentityService.Interfaces;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;

namespace IdentityService.Controllers
{
    /// <summary>
    /// Contains all logic for managing user accounts
    /// </summary>
    [Route("manage")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _accountService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// AuthController constructor requests the <seealso cref="IUserService"/> and <seealso cref="ILogger{ManageController}"/> services
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="logger"></param>
        public UserController(IUserService accountService, ILogger<UserController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        /// <summary>
        /// Get User Account Details
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the user profile<br/> 
        /// A 404 status code prodeced by the <seealso cref="NotFoundObjectResult"/> with error details if user profile could not be found<br/> 
        /// </returns>
        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> GetUserProfile (string username)
        {
            _logger.LogInformation("Updating user model");
            var result = await _accountService.GetUserProfile(username);
            return result.Succeeded ? Ok(result.Result) : NotFound(result.Result);
        }

        /// <summary>
        /// Update User Contact Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the updated student profile<br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if the user could not be updated<br/> 
        /// </returns>
        [HttpPost]
        [Route("{username}")]
        public async Task<IActionResult> UpdateUser([FromBody] ConactModel model)
        {
            _logger.LogInformation("Updating user model");
            var result = await _accountService.UpdateUserContactInformation(model);
            return result.Succeeded ? Ok(result.Result) :  BadRequest(result.Result);
        }

        /// <summary>
        /// Update User Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if the user password could not be updated<br/> 
        /// </returns>
        [HttpPost]
        [Route("{username}/reset")]
        public async Task<IActionResult> ChangeUserPassword(ResetPasswordModel model)
        {
            _logger.LogInformation("Generating Token");
            var token = await _accountService.GeneratePasswordToken(model.Username);
            if (token == null)
            {
                return BadRequest();
            }
            else if (!token.Succeeded)
            {
                return BadRequest(token.Result);
            }           
            model.Token = (string)token.Result;  
            _logger.LogInformation("Resetting Password");
            var result = await _accountService.ResetPassword(model);
            return result.Succeeded ? Ok() : BadRequest(result.Result);
        }

       
    }
}
