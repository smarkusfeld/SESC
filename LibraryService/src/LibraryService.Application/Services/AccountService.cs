using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AccountDTO>> GetAllStudentAccounts()
        {
            var accounts = await _unitOfWork.Accounts.GetAllAsync();
            List<AccountDTO> studentacccounts = new List<AccountDTO>();
            foreach (var account in accounts) 
            {
                ///add conversion

                studentacccounts.Add(new AccountDTO());

            }
            return studentacccounts;
        }

        public async Task<string> Register(string studentid)
        {
            throw new NotImplementedException();
        }
    }
}
