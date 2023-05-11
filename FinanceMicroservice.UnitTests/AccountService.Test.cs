using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.API.Controllers;
using FinanceService.Application.DTOs;
using AutoMapper;
using FinanceMicroservice.UnitTests.Mocks;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;
using FinanceService.Domain.Entities;
using Microsoft.Identity.Client;

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
            var accountDTO = new AccountDTO
            {
                ID = 1,
                StudentID = "c1234567",
                HasOutstandingBalance = false,
            };

            unitOfWork.Setup(x => x.Accounts.Find(1))
                .ReturnsAsync(account);
            var accountService = new AccountService(unitOfWork.Object, mapper);
            //act
            var result = accountService.GetAccountById(1);
            var resultAccount = result.Result;
            //assert
            Assert.NotNull(result);
            Assert.IsType<AccountDTO>(resultAccount);
            Assert.True(account.Equals(account));
        }
        
        
        private List<Account> GetaccountList()
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
