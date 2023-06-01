using LibraryService.Application.Interfaces;
using LibraryService.Application.Models;
using LibraryService.Application.Services;
using LibraryService.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly ILogger<AccountController> _logger;
      
       

        public AccountController(ILogger<AccountController> logger, IAccountService service)
        {
            _logger = logger;
            _service = service;
        }

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
        public async Task<IActionResult> Register(StudentRegistrationModel userModel)
        {
            throw new NotImplementedException();
            //var user = _mapper.Map<User>(userModel);
            //map modeul to user
            //var role = await _userManager.AddToRoleAsync(user, "Visitor");
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(userModel);
            //}
            //var user = await _userManager.FindByEmailAsync(userModel.Email);
            //if (user != null &&
            //    await _userManager.CheckPasswordAsync(user, userModel.Pin))
            //{
            //    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            //    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
            //        new ClaimsPrincipal(identity));
            //    //return RedirectToAction(nameof(HomeController.Index), "Home");
            //    return View();
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Invalid UserName or Password");
            //    return View();
            //}
            return View();
        }

    }
}
