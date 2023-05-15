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

        public async Task<bool> CreateAccount(string studentId)
        {
            // Validation logic
            AccountDTO accountDTO = new AccountDTO
            {
                StudentID = studentId,
                HasOutstandingBalance = false,
            };
            var account = _mapper.Map<Account>(accountDTO);
            if (account != null)
            {
                await _unitOfWork.Accounts.Create(account);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteAccount(int accountID)
        {
            var account = await _unitOfWork.Accounts.Find(accountID);
            if (account != null)
            {
                _unitOfWork.Accounts.Delete(account);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<AccountDTO> GetAccountById(int accountID)
        {
            var account = await _unitOfWork.Accounts.Find(accountID);
            
            return _mapper.Map<AccountDTO>(account);
        }
        public async Task<AccountDTO> GetStudentAccount(string studentID)
        {
            
            var account = await _unitOfWork.Accounts.FindWhere(x => x.StudentID == studentID);
            return _mapper.Map<AccountDTO>(account);
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var accountList = await _unitOfWork.Accounts.FindAll();
            var accountDTOList = new List<AccountDTO>();
            foreach (var account in accountList)
            {
                accountDTOList.Add(_mapper.Map<AccountDTO>(account));
            }
            return accountDTOList.AsEnumerable();
        }

      
        public async Task<bool> UdateAccount(AccountDTO accountDTO)
        {
            var check = await _unitOfWork.Accounts.Find(accountDTO.ID);
            if (check != null)
            {
                var account = _mapper.Map<Account>(accountDTO);
                _unitOfWork.Accounts.Update(account);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public  Task<bool> UpsertAccount(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }
        private AccountDTO checkBalance(AccountDTO accountDTO)
        {
            var balance = GetAccountBalance(accountDTO.ID).Result;
            if (balance > 0)
            {
                accountDTO.HasOutstandingBalance = false;
            }
            else
            {
                accountDTO.HasOutstandingBalance = true;
            }
            return accountDTO;
        }
        private async Task<decimal> GetAccountBalance(int accountID)
        {
            var all = await _unitOfWork.Invoices.FindAllWhere(x => x.Account.ID == accountID);
            return all.Sum(x => x.Balance);
        }
    }
}
