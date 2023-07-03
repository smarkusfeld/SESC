using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    { 
        private readonly JwtTokenService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(JwtTokenService jwtService, ILogger<AuthController> logger)
        {
            _jwtService = jwtService;
            _logger = logger;
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            
            var token = await _jwtService.GenerateAuthToken(model);
            return token == null
                ? Unauthorized()
                : Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = (int)token.ValidTo.Subtract(DateTime.Now).TotalSeconds
                });            
        }
        
        /// <summary>
        /// Register student user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register/student")]
        public async Task<IActionResult> RegisterStudentUser([FromBody] RegistrationModel model)
        {
            List<string> roles = new() { "User", "Student" };
            var registerStudent = await _jwtService.RegisterUser(model, roles);
            return registerStudent
            ? Ok(new Response { Status = "Success", Message = "User created successfully!" })
            : StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        
        }

        /// <summary>
        /// register admin user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register/{dept}")]
        public async Task<IActionResult> RegisterAdminUser([FromBody] RegistrationModel model, string dept)
        {

            List<string> roles = new() { "User", "Admin",dept};
            string[] scopes = new string[] { "admin" };
            var registerAdmin = await _jwtService.RegisterUser(model, roles, scopes);
            return registerAdmin
            ? Ok(new Response { Status = "Success", Message = "User created successfully!" })
            : StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        }

        /// <summary>
        /// register guest user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register/guest")]
        public async Task<IActionResult> RegisterGuestUser([FromBody] RegistrationModel model)
        {
            List<string> roles = new() { "User" };
            var registerStudent = await _jwtService.RegisterUser(model, roles);
            return registerStudent
            ? Ok(new Response { Status = "Success", Message = "User created successfully!" })
            : StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        }

        
    }
}
