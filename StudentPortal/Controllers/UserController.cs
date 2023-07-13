using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudentPortal.Models;
using StudentPortal.Models.ViewModels;
using StudentPortal.Services;
using System.Diagnostics;
using System.Text.Json;
using System.Web.Helpers;

namespace StudentPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _identityService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _identityService = userService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Register User 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel userModel)
        {
            _logger.LogInformation("Validating Model");
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            _logger.LogInformation("Registering User");
            var result = await _identityService.RegisterStudent(userModel);
            if(result.Succeeded)
            {
                _logger.LogInformation("User Registered Successfully");
                return View(JsonSerializer.Deserialize<UserRegisteredModel>(result.ResultContent)!);
            }
            else if(!result.Succeeded)
            {
                _logger.LogInformation("Unable to register user");
                var responseCode = result.ResponseCode;
                var errors = JsonSerializer.Deserialize<List<ErrorMessage>>(result.ResultContent)!;
                return Error(responseCode, errors); 
            }
            _logger.LogInformation("Unable to complete request to identity service");
            return Error();
        }

        /// <summary>
        /// Generic Error Page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Errror Page with Details from API service
        /// </summary>
        /// <param name="responseCode"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int responseCode, List<ErrorMessage> errors)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ResponseCode = responseCode,
                Errors = errors
            });
        }
    }
}