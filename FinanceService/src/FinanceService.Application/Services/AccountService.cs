using AutoMapper;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceService.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean value
        /// </returns>
        public async Task<bool> CreateAccount(string studentID)
        {
            AccountDTO dto = new AccountDTO
            {
                StudentID = studentID,
                HasOutstandingBalance = false,
            };
            var account = _mapper.Map<Account>(dto);
            var newAccount = await _unitOfWork.Accounts.AddAsync(account);
            if (newAccount != null)
            {
                var result = _unitOfWork.Save();
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteAccount(int accountID)
        {
            var account = await _unitOfWork.Accounts.GetAsync(accountID);
            _unitOfWork.Accounts.Delete(account);
            var result = _unitOfWork.Save();
            return result > 0 ? true : false;
        }

        public async Task<AccountDTO> GetAccountById(int accountID)
        {
            var account = await _unitOfWork.Accounts.GetAsync(accountID);
            AccountDTO dto = _mapper.Map<AccountDTO>(account);
            dto.HasOutstandingBalance = await AccountHasOutstandingBalance(dto);
            return dto;
        }
        public async Task<AccountDTO> GetStudentAccount(string studentID)
        {
            var account = await _unitOfWork.Accounts.GetByAsync(x => x.StudentID == studentID);
            AccountDTO dto = _mapper.Map<AccountDTO>(account);
            dto.HasOutstandingBalance = await AccountHasOutstandingBalance(dto);
            return dto;


        }
        public async Task<bool> StudentAccountExists(string studentID)
        {
            var account = await _unitOfWork.Accounts.GetByAsync(x => x.StudentID == studentID);
            return account != null? true: false;
        }
        
        public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var accountList = await _unitOfWork.Accounts.GetAllAsync();
            var accountDTOList = new List<AccountDTO>();
            foreach (var account in accountList)
            {
                AccountDTO dto = _mapper.Map<AccountDTO>(account);
                dto.HasOutstandingBalance = await AccountHasOutstandingBalance(dto);
                accountDTOList.Add(dto);
            }
            return accountDTOList.AsEnumerable();
        }

      
        public async Task<bool> UpdateAccount(AccountDTO accountDTO)
        {
            var check = await _unitOfWork.Accounts.GetAsync(accountDTO.ID);
            if (check != null)
            {
                var account = _mapper.Map<Account>(accountDTO);
                _unitOfWork.Accounts.Update(account);
                var result = _unitOfWork.Save();
                return result > 0 ? true : false;
            }
            return false;
        }
        public  Task<bool> UpsertAccount(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> AccountHasOutstandingBalance(AccountDTO dto)
        {
            var invoices = await _unitOfWork.Invoices.GetAllWhereAsync(x => x.AccountID == dto.ID);
            decimal total = invoices.Sum(x => x.Balance);
            return total > 0;
        }
        
    }
}
