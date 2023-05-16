using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.Api.Controllers;
using FinanceService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using AutoMapper.Execution;

namespace FinanceMicroservice.UnitTests
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountService> accountService;
        
        public AccountControllerTest()
        {
            accountService = new Mock<IAccountService>();
        }
        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            //arrange
            var accountDTOs = GetaccountDTOList();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountDTOs);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

        }
        [Fact]
        public void GetAll_TaskResultAccountDTOList()
        {
            //arrange
            var accountDTOs = GetaccountDTOList();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountDTOs);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<List<AccountDTO>>(actionResult.Value);
            Assert.Equal(accountDTOs, actionResult.Value);
        }
        [Fact]
        public void GetAll_ReturnsOkResultNoRecords()
        {
            //arrange
            IEnumerable<AccountDTO> noReccords = new List<AccountDTO>();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(noReccords);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public void GetAll_TaskResultNoRecords()
        {
            //arrange
            IEnumerable<AccountDTO> noReccords = new List<AccountDTO>();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(noReccords);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert

            Assert.IsType<List<AccountDTO>>(actionResult.Value);
            Assert.Equal(noReccords, actionResult.Value);
        }
        [Fact]
        public void GetAll_ReturnsBadRequest()
        {
            //arrange            
            accountService.Setup(x => x.GetAllAccounts())
                .Returns(Task.FromResult<IEnumerable<AccountDTO>>(null));
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetAll();
            var actionResult = result as BadRequestResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void Get_ReturnsOkResult()
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
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.Get(1);
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public void Get_ReturnsAccountDTO()
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
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.Get(1);
            var actionResult = result as ObjectResult;

            //assert
            Assert.IsType<AccountDTO>(actionResult.Value);
            Assert.Equal(accountDTO, actionResult.Value);
        }
        [Fact]
        public void Get_ReturnsReturnsNotFound()
        {
            //arrange
            accountService.Setup(x => x.GetAccountById(1))
                .Returns(Task.FromResult<AccountDTO>(null)); 
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.Get(1);
            var actionResult = result as NotFoundResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void GetStudentAccount_ReturnsOkResult()
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
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetStudentAccount("c1234567");
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public void CreateAccount_False_ReturnsBadRequestResult()
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
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.CreateAccount("c1234567");
            var actionResult = result as BadRequestResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public void DeleteAccount_ReturnsOkResult()
        {
            accountService.Setup(x => x.DeleteAccount(1))
                .ReturnsAsync(true);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.Delete(1);
            var actionResult = result as OkResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteAccount_ReturnsBadRequestResult()
        {
            accountService.Setup(x => x.DeleteAccount(1))
                .ReturnsAsync(false);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.Delete(1);
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