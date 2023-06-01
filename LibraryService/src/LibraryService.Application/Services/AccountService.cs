using LibraryService.Application.DTOs;
using LibraryService.Application.Interfaces;
using LibraryService.Application.Models;
using LibraryService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly IValidationDictionary _validatonDictionary;
        private readonly UserManager<User> _userManager;
        public AccountService(IValidationDictionary validationDictionary, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _validatonDictionary = validationDictionary;
            _unitOfWork = unitOfWork;

            _userManager = userManager;
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

        

        public async Task<bool> RegisterAccount(string studentID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterStudent(string studentID)
        {
            var account = new Account
            {
                StudentId = studentID,
                Pin = 000000
            };
            var user = new User
            {
                AccountId = account.Id,
            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _validatonDictionary.AddError(error.Code, error.Description);
                }
                return false;
            }
        }
        public bool ValidateAccount(StudentRegistrationModel model)
        {
            if (model.StudentID.Trim().Length == 0)
            {
                _validatonDictionary.AddError("StudentID", "Name is required.");
            }
            var acccount = _unitOfWork.Accounts.GetByAsync(x=>x.StudentId ==  model.StudentID);
            if (acccount != null)
            {
                _validatonDictionary.AddError("StudentID", "Account already associated with acccount");
            }

            //if (student.Description.Trim().Length == 0)
            // _validatonDictionary.AddError("Description", "Description is required.");
            return _validatonDictionary.IsValid;
        }
    }
}
