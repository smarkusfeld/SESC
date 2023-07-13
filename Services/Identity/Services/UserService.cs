using IdentityService.Interfaces;
using IdentityService.Models;
using IdentityService.Models.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Common;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.Net;

namespace IdentityService.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : IUserService
    {
        //Provides the APIs for managing user in a persistence store
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        /// <summary>
        /// Provides the servies for manging a user in a persistence store
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Update User Contact Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A task that contains the <seealso cref="IdentityResult"/></returns>
        public async Task<IdentityResult> UpdateUserContactInformation(ConactInputModel model)
        {
            
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                var errors = new List<IdentityError>
                {
                    new IdentityError()
                    {
                        Code = "NotFound",
                        Description = "User: " + model.Username + " does not exist",
                    }
                };
                return IdentityResult.Failed(errors.ToArray());
            }
            user.PhoneNumber = model.PhoneNumber;
            user.FirstName = model.FirstName;
            user.Surname = model.Surname;
            user.MiddleName = model.MiddleName;
            user.Email = model.Email;
            user.Address = new Address
                {
                    LineOne = model.PermanentAddressLineOne ?? string.Empty,
                    LineTwo = model.PermanentAddressLineTwo ?? string.Empty,
                    LineThree = model.PermanentAddressLineThree ?? string.Empty,
                    Town_City = model.PermanentAddressTown_City ?? string.Empty,
                    County_Region = model.PermanentAddressCounty_Region ?? string.Empty,
                    PostCode = model.PermanentAddressPostCode ?? string.Empty,
                    Country = model.PermanentAddressCountry ?? string.Empty,
                };
            user.TermAddress = new Address
            {
                LineOne = model.TermAddressLineOne ?? string.Empty,
                LineTwo = model.TermAddressLineTwo ?? string.Empty,
                LineThree = model.TermAddressLineThree ?? string.Empty,
                Town_City = model.TermAddressTown_City ?? string.Empty,
                County_Region = model.TermAddressCounty_Region ?? string.Empty,
                PostCode = model.TermAddressPostCode ?? string.Empty,
                Country = model.TermAddressCountry ?? string.Empty,
            };
            return await _userManager.UpdateAsync(user);
        }

        /// <summary>
        /// Reset User Password
        /// </summary>
        /// <param name="model"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IdentityResult> ResetPassword(ResetPasswordModel model, string token)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            return await _userManager.ResetPasswordAsync(user, token, model.Password);
        }

        /// <summary>
        /// Create Token to Reset User Password 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<string> GeneratePasswordToken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}
