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
    /// <summary>
    /// Controller adapted from https://www.c-sharpcorner.com/article/jwt-authentication-and-authorization-in-net-6-0-with-identity-framework/ 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    { 
        private readonly JwtTokenService _jwtService;

        public AuthController(JwtTokenService jwtService)
        {
            _jwtService = jwtService;
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
            var registerAdmin = await _jwtService.RegisterUser(model, roles);
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
