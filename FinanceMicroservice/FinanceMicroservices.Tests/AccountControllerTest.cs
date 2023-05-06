using FinanceMicroservice.Application;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Controllers;
using Moq;

namespace FinanceMicroservice.Tests
{
    public class AccountControllerTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IAccountRepository> _mockAccounts;
        private readonly Mock<IInvoiceRepository> _invoices;
        private readonly Mock<IPaymentRepository> _payments;
        private readonly AccountController _controller;

        //private readonly IFinanceService<Account> _service;


        public AccountControllerTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mockAccounts = new Mock<IAccountRepository>();
            _invoices = new Mock<IInvoiceRepository>();
            _payments = new Mock<IPaymentRepository>();
            //_controller = new AccountController(_service);
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            //act
            //var result = _controller.Get();

            //assert
            // Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public void GetAll_ReturnsAllAccounts()
        {
            //act
            // var result = _controller.Get();

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
            // var result = _controller.Get();
            //assert
            // Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetById_UnknownID_ReturnsNotFoundResult()
        {
            //arrange
            //add!! add to test repository 
            //act
            // var result = _controller.Get();
            //assert
            // Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void QueryAccount()
        {

        }
    }
}