using LibraryService.Api.Controllers;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Models;
using LibraryService.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Execution;

namespace LibraryService.UnitTests
{

    public class AccountControllerTest
    {
        private readonly Mock<IAccountService> accountService;
        private readonly Mock<ILogger<AccountController>> logger;
        public AccountControllerTest()
        {
            accountService = new Mock<IAccountService>();
            logger = new Mock<ILogger<AccountController>>();
        }
        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            //arrange
            var accountDTOs = GetaccountDTOList();
            accountService.Setup(x => x.GetAllAccounts())
               .ReturnsAsync(accountDTOs);
            var accountController = new AccountController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task GetAll_TaskResultAccountDTOList()
        {
            //arrange
            var accountDTOs = GetaccountDTOList();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountDTOs);
            var accountController = new AccountController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<List<AccountDTO>>(actionResult.Value);
            Assert.Equal(accountDTOs, actionResult.Value);
        }
        [Fact]
        public async Task GetAll_ReturnsNoContent()
        {
            //arrange
            var accountDTOs = Enumerable.Empty<AccountDTO>();
            accountService.Setup(x => x.GetAllAccounts())
               .ReturnsAsync(accountDTOs);
            var accountController = new AccountController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetAll();
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<NoContentResult>(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            //arrange
            AccountDTO accountDTO = new()
            {
                AccountId = "c1234567",
                AccountType = AccountType.Student
            };
            var loanList = GetLoanDTO();
            accountService.Setup(x => x.GetLoanHistory("c1234567"))
                .ReturnsAsync(loanList);
            var accountController = new AccountController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetLoanHistory("c1234567");
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        private static IEnumerable<AccountDTO> GetaccountDTOList()
        {
            IEnumerable<AccountDTO> accountDTOList = new List<AccountDTO>
        {
            new AccountDTO
            {
                AccountId="c1234567",
                AccountType= AccountType.Student
            },
             new AccountDTO
            {
                AccountId="c765321",
                AccountType= AccountType.Student
            },
             new AccountDTO
            {
                AccountId="c1122334",
                AccountType= AccountType.Student
            },
        };
            return accountDTOList;
        }
        private static IEnumerable<LoanDTO> GetLoanDTO()
        {
            IEnumerable<LoanDTO> loanDTOList = new List<LoanDTO>
        {
            new LoanDTO
            {},
             new LoanDTO
            {},
             new LoanDTO
            {},
        };
            return loanDTOList;
        }
    }
}