using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Interfaces
{
    public interface IUserService
    {

        Task<ResultDetail> UpdateUserContactInformation(ConactModel model);
        Task<ResultDetail> GetUserProfile(string username);
        Task<ResultDetail> ResetPassword(ResetPasswordModel model);

        Task<ResultDetail> GeneratePasswordToken(string username);
    }
}
