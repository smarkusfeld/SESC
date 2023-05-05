using System;
using System.Linq.Expressions;
using AutoMapper;
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Domain.Interfaces;

namespace FinanceMicroservice.Application.Services
{

    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper= mapper;
        }

      

        public Task<bool> CheckOutstanding(int accountID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAccount(AccountDTO accountDTO)
        {
            // Validation logic
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

        public Task<int> GetAccountBalance(int accountID)
        {
            throw new NotImplementedException();
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

        public Task<AccountDTO> GetAccountById(int accountID)
        {
            throw new NotImplementedException();
        }
        public Task<AccountDTO> GetStudentAccount(int studentID)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateProduct(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoices(int accountID)
        {
            var invoiceList = await _unitOfWork.Invoices.FindAllWhere(x => x.Account.ID == accountID);
            var invoiceDTOList = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                invoiceDTOList.Add(_mapper.Map<InvoiceDTO>(invoice));
            }
            return invoiceDTOList.AsEnumerable();
        }

        public async Task<IEnumerable<InvoiceDTO>> GetOutstandingInvoices(int accountID)
        {
            var all = await GetAllInvoices(accountID);
            return all.Where(x => x.Status == Domain.Enums.InvoiceStatus.Outstanding);
        }


        //create account

        //accountdto

        //getallaccounts

        //getbystudentid

        //create new account

        //upsert account

        //delete account

        //check account balance
    }
}
