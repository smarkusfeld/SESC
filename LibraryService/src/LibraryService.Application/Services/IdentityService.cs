using LibraryService.Application.Interfaces;
using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Account> _userManager;
        public IdentityService(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }
        public Task<bool> CreateStudentAccount(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterStudent(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserFirstLogin(UserFirstLoginModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserLogin(UserLoginModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
