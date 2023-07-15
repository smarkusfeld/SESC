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
        /// Get User Profile
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ResultDetail> GetUserProfile(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return ResultDetail.FailedResult(ResultError.UserNotFound(username));
            }
            
            return ResultDetail.SuccessResult(new ConactModel
            {
                FirstName = user.FirstName,
                Surname = user.Surname,
                MiddleName = user.MiddleName,
                Email = user.Email,
                SchoolEmail = user.Email,
                PhoneNumber = user.PhoneNumber,
                PermanentAddressLineOne = user.Address.LineOne ?? string.Empty,
                PermanentAddressLineTwo = user.Address.LineTwo ?? string.Empty,
                PermanentAddressLineThree = user.Address.LineThree ?? string.Empty,
                PermanentAddressTown_City = user.Address.Town_City ?? string.Empty,
                PermanentAddressCounty_Region = user.Address.County_Region ?? string.Empty,
                PermanentAddressPostCode = user.Address.PostCode ?? string.Empty,
                PermanentAddressCountry = user.Address.Country ?? string.Empty,
                TermAddressLineOne = user.Address.LineOne ?? string.Empty,
                TermAddressLineTwo = user.Address.LineTwo ?? string.Empty,
                TermAddressLineThree = user.Address.LineThree ?? string.Empty,
                TermAddressTown_City = user.Address.Town_City ?? string.Empty,
                TermAddressCounty_Region = user.Address.County_Region ?? string.Empty,
                TermAddressPostCode = user.Address.PostCode ?? string.Empty,
                TermAddressCountry = user.Address.Country ?? string.Empty,
            });
        }

        /// <summary>
        /// Update User Contact Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A task that contains the <seealso cref="IdentityResult"/></returns>
        public async Task<ResultDetail> UpdateUserContactInformation(ConactModel model)
        {
            var errors = new List<ResultError>();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return ResultDetail.FailedResult(ResultError.UserNotFound(model.Username));
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
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                errors.AddRange(ConvetIdentityResult(result.Errors));
            }
            return !errors.Any()
               ? ResultDetail.FailedResult(errors.ToArray())
               : ResultDetail.SuccessResult(user);
        }

        /// <summary>
        /// Reset User Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultDetail> ResetPassword(ResetPasswordModel model)
        {
            var errors = new List<ResultError>();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {                
                return ResultDetail.FailedResult(ResultError.UserNotFound(model.Username));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                errors.AddRange(ConvetIdentityResult(result.Errors));
            }
            return !errors.Any()
               ? ResultDetail.FailedResult(errors.ToArray())
               : ResultDetail.Success;
        }

        /// <summary>
        /// Create Token to Reset User Password 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ResultDetail> GeneratePasswordToken(string username)
        {
            var errors = new List<ResultError>();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return ResultDetail.FailedResult(ResultError.UserNotFound(username));
            }
            var result = await _userManager.GeneratePasswordResetTokenAsync(user);
            return result == null
               ? ResultDetail.FailedResult(ResultError.DefaultError())
               : ResultDetail.SuccessResult(result);
        }

        private IEnumerable<ResultError> ConvetIdentityResult(IEnumerable<IdentityError> errors)
        {
            var result = new List<ResultError>();
            foreach (IdentityError error in errors)
            {
                result.Add(new ResultError() { Code = error.Code, Description = error.Description });
            }
            return result;
        }
    }
}
