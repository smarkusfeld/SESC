using LibraryService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> CreateStudentAccount(string studentId);

        Task<bool> RegisterStudent(string studentId);

        Task<bool> UserFirstLogin(UserFirstLoginModel userModel);

        Task<bool> UserLogin(UserLoginModel userModel);

        
    }
}
