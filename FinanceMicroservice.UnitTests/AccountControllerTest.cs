using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.API.Controllers;
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
            var accountDTOs = GetaccoutDTOList();
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
            var accountDTOs = GetaccoutDTOList();
            accountService.Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountDTOs);
            var accountController = new AccountController(accountService.Object);
            //act
            var result = accountController.GetAll();
            var actionResult = result as ObjectResult;

            //assert
            Assert.IsType<List<AccountDTO>>(actionResult.Value);
            Assert.Equal(accountDTOs, actionResult.Value);
        }
        [Fact]
        public void GetAll_ReturnsOkResultNoRecords()
        {
            //arrange
            IEnumerable<AccountDTO> noReccords = new List<AccountDTO>();
            accountService.Setup(x => x.GetAllAccounts().Result)
                .Returns(noReccords);
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
            var actionResult = result as ObjectResult;

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
        
        




        private IEnumerable<AccountDTO> GetaccoutDTOList()
        {
            IEnumerable<AccountDTO> accoutDTOList = new List<AccountDTO>
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
            return accoutDTOList;
        }
    }
}