using IdentityService.DataContext;
using IdentityService.Interfaces;
using IdentityService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtTokenService : IJwtTokenService
    {
        //Provides the APIs for managing user in a persistence store
        private readonly UserManager<User> _userManager;
        //Provides the APIs for managing roles in a persistence store
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        protected readonly IdentityDataContext _context;
        protected readonly DbSet<UserIdentifer> _set;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="usernameService"></param>
        /// <param name="configuration"></param>
        public JwtTokenService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IdentityDataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _set = _context.Set<UserIdentifer>();
        }


    
        public async Task<ResultDetail> GenerateAuthToken(LoginModel loginModel)
        {
            //check user
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user == null) { return ResultDetail.FailedResult(ResultError.UserNotFound(userName: loginModel.Username ?? string.Empty)); }
            
            //check password
            if (await _userManager.CheckPasswordAsync(user, loginModel.Password))
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
                return ResultDetail.SuccessResult(GetToken(authClaims));
            }
            return ResultDetail.FailedResult(ResultError.InvalidPassword(userName: loginModel.Username ?? string.Empty));

        }
       
        public async Task<ResultDetail> RegisterUser(RegistrationModel model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Email); 
            if(existingUser != null)
            {
                return (string.IsNullOrEmpty(model.Email))
                     ? ResultDetail.FailedResult(ResultError.InvalidEmail())
                     : ResultDetail.FailedResult(ResultError.UserAlreadyExists(model.Email));             
            }
            //generate username 
            var userIdentifer = await GenerateUsername('c');
            if(userIdentifer == null) { return ResultDetail.FailedResult(ResultError.UsernameUnavailable()); }
            User user = new(userIdentifer)
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userIdentifer.Identifer,
                SchoolEmail = model.SchoolEmail,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Surname = model.Surname,
            };

            var reg = await _userManager.CreateAsync(user, model.Password);
            if (!reg.Succeeded) 
            {
                var errors = ConvetIdentityResult(reg.Errors);
                return ResultDetail.FailedResult(errors.ToArray());
            }

            var roleResult = await AddUserRoles(user, model.Roles); 
            if(!roleResult.Succeeded)
            {
                return roleResult;
            }
            return ResultDetail.SuccessResult(new
            {
                Name = $"{user.FirstName} {user.Surname}",
                UserName = userIdentifer.Identifer,
                UserNo = userIdentifer.UserNumber
            });
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        private async Task<ResultDetail> AddUserRoles(User user, string roles)
        {
            var roleNames = roles.Split(',');
            var errors = new List<ResultError>();
            foreach (string role in roleNames)
            {                
                IdentityResult roleresult = await _userManager.AddToRoleAsync(user, role);
                if (!roleresult.Succeeded) 
                {                    
                    errors.AddRange(ConvetIdentityResult(roleresult.Errors));
                }
            }
            return !errors.Any() 
                ? ResultDetail.FailedResult(errors.ToArray()) 
                : ResultDetail.Success;
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

        private async Task<UserIdentifer?> GenerateUsername(char prefix)
        {
            var identifier = new UserIdentifer(prefix);
            _set.Add(identifier);
            return await _context.SaveChangesAsync() >0 
                    ? identifier
                    : null;
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
