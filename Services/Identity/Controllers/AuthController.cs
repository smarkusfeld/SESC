using IdentityService.Interfaces;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;


namespace IdentityService.Controllers
{
    /// <summary>
    /// Contains all authentication and registration logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    { 
        private readonly IJwtTokenService _jwtService;
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// AuthController constructor requests the <seealso cref="IJwtTokenService"/> and <seealso cref="ILogger{AuthController}"/> services
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="logger"></param>
        public AuthController(IJwtTokenService jwtService, ILogger<AuthController> logger)
        {
            _jwtService = jwtService;
            _logger = logger;
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the <seealso cref="JwtSecurityToken"/> and the token expiration<br/> 
        /// A 401 status code produced by the <seealso cref="NotFoundResult"/> the request was not authorized 
        /// </returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            _logger.LogInformation("Generating JWT Token");
            var result = await _jwtService.GenerateAuthToken(model);
            var token = (JwtSecurityToken)result.Result;
            _logger.LogInformation("Issuing Token");
            return result.Succeeded && token != null
                ? Ok(new
                {
                    
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = (int)token.ValidTo.Subtract(DateTime.Now).TotalSeconds
                })
                : Unauthorized(result.Result);                 
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with <seealso cref="ResultDetail"/> contained the new username
        /// A 400 status code produced by the <seealso cref="BadRequestResult"/> with <seealso cref="ResultDetail"/> containing the error details
        /// </returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationModel model)
        {
            _logger.LogInformation("Registering User");
            var result = await _jwtService.RegisterUser(model);
            _logger.LogInformation("Registration Complete User");
            return result.Succeeded
                ? Ok(result.Result)
                : BadRequest(result.Result);        
        }

       
        

        
    }
}
