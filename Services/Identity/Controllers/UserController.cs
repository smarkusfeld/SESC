using IdentityService.Interfaces;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;
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
        /// Update User Contact Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> <br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestObjectResult"/> if the user could not be updated<br/> 
        /// </returns>
        [HttpPost]
        [Route("contact")]
        public async Task<IActionResult> UpdateUser([FromBody] ConactInputModel model)
        {
            _logger.LogInformation("Updating user model");
            var result = await _accountService.UpdateUserContactInformation(model);
            return result.Succeeded ? Ok("Updated User Details Sucessfully") :  BadRequest(result.Errors);
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
        [Route("reset")]
        public async Task<IActionResult> ChangeUserPassword(ResetPasswordModel model)
        {
            _logger.LogInformation("Generating Token");
            var token = await _accountService.GeneratePasswordToken(model.Username);
            _logger.LogInformation("Resetting Password");
            var result = await _accountService.ResetPassword(model, token);
            return result.Succeeded ? Ok("PasswordUpdated") : BadRequest(result.Errors);
        }

       
    }
}
