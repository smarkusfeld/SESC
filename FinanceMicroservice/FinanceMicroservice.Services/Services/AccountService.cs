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

        public Task<bool> CreateAccount(AccountDTO accountDTO)
        {
            var account = _mapper.Map<Account>(accountDTO);

            
            throw new NotImplementedException();

            
        }

        public Task<bool> DeleteAccount(int accountID)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccountBalance(int accountID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> GetProductById(int accountID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
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
