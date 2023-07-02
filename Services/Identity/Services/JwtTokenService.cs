using IdentityService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtTokenService
    {
        //Provides the APIs for managing user in a persistence store
        private readonly UserManager<IdentityUser> _userManager;
        //Provides the APIs for managing roles in a persistence store
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

       

        public JwtTokenService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<JwtSecurityToken> GenerateAuthToken(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                //get all user roles associated with user
                var userRoles = await _userManager.GetRolesAsync(user);

                //create claim list
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                //user roles to claims
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                return GetToken(authClaims);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleNames"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUser(RegistrationModel model, List<string>roleNames)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Username); 
            if(existingUser != null){return false;}
            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) 
            {
                return await AddUserRoles(user, roleNames);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleNames"></param>
        /// <returns></returns>
        private async Task<bool> AddUserRoles(IdentityUser user, List<string> roleNames)
        {
            foreach (string roleName in roleNames)
            {
                var normalizedRoleName = _userManager.NormalizeName(roleName);
                var role = _roleManager.FindByNameAsync(normalizedRoleName).Result;
                if (role == null){return false;}
                IdentityResult roleresult = await _userManager.AddToRoleAsync(user, role.Name);
                if (!roleresult.Succeeded) { return false; }

            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authClaims"></param>
        /// <returns></returns>
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
