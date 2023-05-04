using FinanceMicroservice.Controllers;
using FinanceMicroservice.Domain.Entities;
using FinanceMicroservice.Infastructure;
using FinanceMicroservice.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit.Abstractions;


namespace FinanceMicroservice.Tests
{
    public class AccountControllerTest
    {
        private readonly AccountController _controller;
        //private readonly IFinanceService<Account> _service;


        public AccountControllerTest()
        {
            //_service = new AccountService();
            //_controller = new AccountController(_service);
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            //act
            var result = _controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public void GetAll_ReturnsAllAccounts()
        {   
            //act
            var result = _controller.Get();

            //assert
            //var accounts = Assert.IsType<List<Account>>(result.Value);
            //Assert.Equal(3, accounts.Count);

        }

        [Fact]
        public void GetById_KnownID_ReturnsOKResult()
        {
            //arrange
            //add!! add to test repository 

            //act
            var result = _controller.Get();
            //assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetById_UnknownID_ReturnsNotFoundResult()
        {
            //arrange
            //add!! add to test repository 
            //act
            var result = _controller.Get();
            //assert
           // Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void QueryAccount()
        {

        }
    }
}