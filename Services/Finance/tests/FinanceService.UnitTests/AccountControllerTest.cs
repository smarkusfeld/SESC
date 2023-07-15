using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.Api.Controllers;
using FinanceService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using AutoMapper.Execution;
using AutoMapper.Internal;
using Xunit;
using Microsoft.Extensions.Logging;
using NLog;

namespace FinanceMicroservice.UnitTests
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountService> accountService;
        private readonly Mock<ILogger<AccountsController>> logger;
        public AccountControllerTest()
        {
            accountService = new Mock<IAccountService>();
            logger = new Mock<ILogger<AccountsController>>();
        }
        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            //arrange
            var accountDTOs = GetaccountDTOList();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountDTOs);
            var accountController = new AccountsController(accountService.Object, logger.Object);
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
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<List<AccountDTO>>(actionResult.Value);
            Assert.Equal(accountDTOs, actionResult.Value);
        }
        [Fact]
        public async Task GetAll_TaskResultNullReturnsBadRequest()
        {
            //arrange
            IEnumerable<AccountDTO> noReccords = new List<AccountDTO>();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(noReccords);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetAll();
            var actionResult = result as BadRequestObjectResult;

            //assert
            Assert.Equal(400, actionResult.StatusCode);
        }
        [Fact]
        public async Task GetAll_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<AccountDTO> noReccords = new List<AccountDTO>();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(noReccords);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetAll();
            var actionResult = result as BadRequestObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
       
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            //arrange
            AccountDTO accountDTO = new AccountDTO
            {
                ID = 1,
                StudentID = "c1234567",
                HasOutstandingBalance = false,
            };

            accountService.Setup(x => x.GetAccountById(1))
                .ReturnsAsync(accountDTO);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.Get(1);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task Get_ReturnsAccountDTO()
        {
            //arrange
            AccountDTO accountDTO = new AccountDTO
            {
                ID = 1,
                StudentID = "c1234567",
                HasOutstandingBalance = false,
            };

            accountService.Setup(x => x.GetAccountById(1))
                .ReturnsAsync(accountDTO);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.Get(1);
            var actionResult = result as ObjectResult;

            //assert
            Assert.IsType<AccountDTO>(actionResult.Value);
            Assert.Equal(accountDTO, actionResult.Value);
        }
        [Fact]
        public async Task Get_ReturnsReturnsNotFound()
        {
            //arrange
            accountService.Setup(x => x.GetAccountById(1))
                .Returns(Task.FromResult<AccountDTO>(null)); 
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.Get(1);
            var actionResult = result as NotFoundResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetStudentAccount_ReturnsOkResult()
        {
            //arrange
            AccountDTO accountDTO = new AccountDTO
            {
                ID = 1,
                StudentID = "c1234567",
                HasOutstandingBalance = false,
            };

            accountService.Setup(x => x.GetStudentAccount("c1234567"))
                .ReturnsAsync(accountDTO);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.GetStudentAccount("c1234567");
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task CreateAccount_False_ReturnsBadRequestResult()
        {
            //arrange
            AccountDTO accountDTO = new AccountDTO
            {
                ID = 1,
                StudentID = "c1234567",
                HasOutstandingBalance = false,
            };
            accountService.Setup(x => x.CreateAccount(accountDTO))
                .ReturnsAsync(false);
            var accountController = new AccountsController(accountService.Object, logger.Object);
            //act
            var result = await accountController.CreateAccount("c1234567");
            var actionResult = result as BadRequestResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task DeleteAccount_ReturnsOkResult()
        {
            accountService.Setup(x => x.DeleteAccount(1))
                .ReturnsAsync(true);
            var accountController = new AccountController(accountService.Object, logger.Object);
            //act
            var result = await accountController.Delete(1);
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task DeleteAccount_ReturnsBadRequestResult()
        {
            accountService.Setup(x => x.DeleteAccount(1))
                .ReturnsAsync(false);
            var accountController = new AccountController(accountService.Object, logger.Object);
            //act
            var result = await accountController.Delete(1);
            var actionResult = result as BadRequestResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
        private IEnumerable<AccountDTO> GetaccountDTOList()
        {
            IEnumerable<AccountDTO> accountDTOList = new List<AccountDTO>
        {
            new AccountDTO
            {
                ID=1,
                StudentID="c1234567",
                HasOutstandingBalance=false,
            },
             new AccountDTO
            {
                ID=2,
                StudentID="c765321",
                HasOutstandingBalance=false,
            },
             new AccountDTO
            {
                ID=3,
                StudentID="c1122334",
                HasOutstandingBalance=false,
            },
        };
            return accountDTOList;
        }
    }
}