using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    public class AccountService : IAccountService
    {
        public Task<IEnumerable<AccountDTO>> GetAllStudentAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(string studentid)
        {
            throw new NotImplementedException();
        }
    }
}
