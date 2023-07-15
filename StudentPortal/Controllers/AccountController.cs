using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;

namespace StudentPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IdentityService _identityService;
        private readonly ILogger<HomeController> _logger;
        public AccountController(IdentityService service, ILogger<HomeController> logger)
        {
            _identityService = service;
            _logger = logger;
        }
        public IActionResult Index()
        {
            HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult StudentUserIndex()
        {
            HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult UserProfile()
        {

        }

        public Task<IActionResult> GetUserProfile(string username)
        {

        }
        public IActionResult Login()
        public async Task<IActionResult> Login(LoginModel model)
        {
            _logger.LogInformation("Validating Model");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _logger.LogInformation("Login Identity Service");
            var result = await _identityService.StudentLogin(model);
            if (result.Succeeded)
            {
                _logger.LogInformation("Login Successful");
                var user = JsonSerializer.Deserialize<LoginResponseModel>(result.ResultContent)!;
                //set session string
                _logger.LogInformation("Starting session for" + user.Username);
                HttpContext.Session.SetString("Username", user.Username);
                _logger.LogInformation("Redirecting to user homepage");
                switch (user.UserHome)
                {
                    case LoginResponseModel.UserRoleIndex.Student:
                        return RedirectToAction("StudentUserIndex");
                    case LoginResponseModel.UserRoleIndex.Factulty:
                    case LoginResponseModel.UserRoleIndex.Admin:
                    case LoginResponseModel.UserRoleIndex.Staff:
                        return RedirectToAction("Index");
                }               
            }
            else if (!result.Succeeded)
            {
                _logger.LogInformation("Login Unsuccessful");
                var responseCode = result.ResponseCode;
                var errors = JsonSerializer.Deserialize<List<ErrorMessage>>(result.ResultContent)!;
                return Error(responseCode, errors);
            }
            _logger.LogInformation("Unable to complete request to identity service");
            return Error();
        }
        /// <summary>
        /// Register User 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(UserRegistrationModel userModel)
        {
            _logger.LogInformation("Validating Model");
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            _logger.LogInformation("Registration Identity Service");
            var result = await _identityService.RegisterStudent(userModel);
            if (result.Succeeded)
            {
                _logger.LogInformation("User Registered Successfully");
                var studentUser = JsonSerializer.Deserialize<UserRegisteredModel>(result.ResultContent)!;

                HttpContext.Session.SetString("Username", studentUser.UserName);
                return RedirectToAction("StudentUserIndex");
            }
            else if (!result.Succeeded)
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
