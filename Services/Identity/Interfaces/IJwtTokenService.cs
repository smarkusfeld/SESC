using IdentityService.Models;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityService.Interfaces
{
    /// <summary>
    /// Contact for JWT Authentication services
    /// </summary>
    public interface IJwtTokenService
    {

        /// <summary>
        /// Generate JWT token for user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns>
        /// A <seealso cref="ResultDetail"/> with a <seealso cref="JwtSecurityToken"/> if the operation was succesful. <br></br>
        /// A <seealso cref="ResultDetail"/> with error details if the operation was unsuccessful 
        /// </returns>
        Task<ResultDetail> GenerateAuthToken(LoginModel loginModel);

        /// <summary>
        /// Register new user 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// A <seealso cref="ResultDetail"/> with the <seealso cref="User"/> username if the operation was succesful. <br></br>
        /// A <seealso cref="ResultDetail"/> with error details if the operation was unsuccessful 
        /// </returns>
        Task<ResultDetail> RegisterUser(RegistrationModel model);
    }
}
