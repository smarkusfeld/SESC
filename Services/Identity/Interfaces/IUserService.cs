using IdentityService.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Interfaces
{
    public interface IUserService
    {

        Task<IdentityResult> UpdateUserContactInformation(ConactInputModel model);

        Task<IdentityResult> ResetPassword(ResetPasswordModel model, string token);

        Task<string> GeneratePasswordToken(string username);
    }
}
