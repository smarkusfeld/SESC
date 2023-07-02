using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.Api.Controllers;
using FinanceService.Application.DTOs;
using AutoMapper;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;
using FinanceService.Domain.Entities;
using Microsoft.Identity.Client;
using System.Security.Principal;
using AutoMapper.Execution;

namespace FinanceMicroservice.UnitTests
{
    public class AccountServiceTests
    {
// private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly IMapper mapper;
        private readonly Mock<IUnitOfWork> unitOfWork;
        public AccountServiceTests()
        {

            unitOfWork = new Mock<IUnitOfWork>();
            mapper = new MappingTests().mapper;
        }

        [Fact]
        public void GetAccountById_ReturnsAccountDTO()
        {
            //arrange
            var account = new Account
            {
                ID = 1,
                StudentID = "c1234567",
                HasOutstandingBalance = false,
            };

            unitOfWork.Setup(x => x.Accounts.GetAsync(1))
                .ReturnsAsync(account);
            var accountService = new AccountService(unitOfWork.Object, mapper);
            //act
            var result = accountService.GetAccountById(1);
            var resultAccount = result.Result;
            //assert
            Assert.NotNull(result);
            Assert.IsType<AccountDTO>(resultAccount);
            Assert.Equal(account.ID, resultAccount.ID);
            Assert.Equal(account.StudentID, resultAccount.StudentID);
            Assert.Equal(account.HasOutstandingBalance, resultAccount.HasOutstandingBalance);
        }
        [Fact]
        public void GetAllAccounts_ReturnsAccountDTOList()
        {
            //arrange
            var accounts = GetAccountList();

            unitOfWork.Setup(x => x.Accounts.GetAllAsync())
                .ReturnsAsync(accounts);
            var accountService = new AccountService(unitOfWork.Object, mapper);
            //act
            var result = accountService.GetAllAccounts();
            var resultObject = result.Result;
            var resultList = result.Result.ToList();
            var resultCount = resultObject.Count();
            
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountDTO>>(resultObject);
            Assert.Equal(accounts.Count, resultCount);
            for(int i = 0; i < resultCount; i++)
            {
                Assert.Equal(accounts[i].ID, resultList[i].ID);
                Assert.Equal(accounts[i].StudentID, resultList[i].StudentID);
                Assert.Equal(accounts[i].HasOutstandingBalance, resultList[i].HasOutstandingBalance);
            }            
        }

        private List<Account> GetAccountList()
        {
            List<Account> accountList = new List<Account>
        {
            new Account
            {
                ID=1,
                StudentID="c1234567",
                HasOutstandingBalance=false,
            },
             new Account
            {
                ID=2,
                StudentID="c765321",
                HasOutstandingBalance=false,
            },
             new Account
            {
                ID=3,
                StudentID="c1122334",
                HasOutstandingBalance=false,
            },
        };
            return accountList;
        }
    }



    
}
