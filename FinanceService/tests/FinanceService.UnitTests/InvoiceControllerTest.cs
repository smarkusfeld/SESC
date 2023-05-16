using Moq;
using FinanceService.Application.Interfaces;
using FinanceService.Api.Controllers;
using FinanceService.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using AutoMapper.Execution;
using FinanceService.Application.Services;


namespace FinanceService.UnitTests
{
    public class InvoiceControllerTest
    {
        private readonly Mock<IInvoiceService> invoiceService;

        public InvoiceControllerTest()
        {
            invoiceService = new Mock<IInvoiceService>();
        }

        [Fact]
        public void GetAll_ReturnsOkResult() 
        {
            //arrange
            var invoiceDTOs = GetInvoiceDTOList();
            invoiceService.Setup(x => x.GetAllInvoices())
                .ReturnsAsync(invoiceDTOs);
            var invoiceController = new InvoiceController(invoiceService.Object);
            //act
            var result = invoiceController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public void GetAll_TaskResultReturnsInvoiceDTOList()
        {
            //arrange
            var invoiceDTOs = GetInvoiceDTOList();
            invoiceService.Setup(x => x.GetAllInvoices())
                .ReturnsAsync(invoiceDTOs);
            var invoiceController = new InvoiceController(invoiceService.Object);
            //act
            var result = invoiceController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<List<InvoiceDTO>>(actionResult.Value);
            Assert.Equal(invoiceDTOs, actionResult.Value);
        }
        [Fact]
        public void GetAll_ReturnsOkResultNoRecords() 
        {
            //arrange
            IEnumerable<InvoiceDTO> invoiceDTOs = new List<InvoiceDTO>();
            invoiceService.Setup(x => x.GetAllInvoices())
                .ReturnsAsync(invoiceDTOs);
            var invoiceController = new InvoiceController(invoiceService.Object);
            //act
            var result = invoiceController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public void GetAll_TaskNoRecords()
        {
            //arrange
            IEnumerable<InvoiceDTO> invoiceDTOs = new List<InvoiceDTO>();
            invoiceService.Setup(x => x.GetAllInvoices())
                .ReturnsAsync(invoiceDTOs);
            var invoiceController = new InvoiceController(invoiceService.Object);
            //act
            var result = invoiceController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<List<InvoiceDTO>>(actionResult.Value);
            Assert.Equal(invoiceDTOs, actionResult.Value);
        }
        [Fact]
        public void Get_ReturnsOkResult() 
        {
            //arrange
            InvoiceDTO invoiceDTO = new InvoiceDTO
            {
                ID = 1,
                StudentID = "c1234567",
                Reference = "inv1234567",
                InvoiceDate = new DateTime(2022, 09, 01),
                DueDate = new DateTime(2023, 01, 01),
                Total = 5000,
                Balance = 5000,
                Type = Domain.Entities.InvoiceType.Tutition,
                Status = Domain.Entities.InvoiceStatus.Outstanding

            };
            invoiceService.Setup(x => x.GetInvoiceById(1))
                .ReturnsAsync(invoiceDTO);
            var invoiceController = new InvoiceController(invoiceService.Object);
            //act
            var result = invoiceController.GetInvoice(1).Result;
            var actionResult = result as OkObjectResult;
            //assert
            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public void Get_TaskResultReturnsInvoiceDTO() { }
        [Fact]
        public void Get_ReturnsBadRequestResult() { }
        [Fact]
        public void CreateInvoice_ReturnsOkResult() { }
        [Fact]
        public void CreateInvoice_ReturnsBadModelState() { }
    
    private IEnumerable<InvoiceDTO> GetInvoiceDTOList()
    {
        IEnumerable<InvoiceDTO> invoiceDTOList = new List<InvoiceDTO>
        {
            new InvoiceDTO
            {
                ID=1,
                StudentID="c1234567",
                Reference = "inv1234567",
                InvoiceDate = new DateTime(2022, 09, 01),
                DueDate = new DateTime(2023, 01, 01),
                Total = 5000,
                Balance = 5000,
                Type = Domain.Entities.InvoiceType.Tutition,
                Status = Domain.Entities.InvoiceStatus.Outstanding

            },
             new InvoiceDTO
            {
                ID=2,
                StudentID="c765321",
                Reference = "inv765321",
                InvoiceDate = new DateTime(2022, 09, 01),
                DueDate = new DateTime(2023, 01, 01),
                Total = 5000,
                Balance = 5000,
                Type = Domain.Entities.InvoiceType.Tutition,
                Status = Domain.Entities.InvoiceStatus.Outstanding
            },
             new InvoiceDTO
            {
                ID=3,
                StudentID="c1122334",
                Reference = "inv765321",
                InvoiceDate = new DateTime(2022, 09, 01),
                DueDate = new DateTime(2023, 01, 01),
                Total = 5000,
                Balance = 5000,
                Type = Domain.Entities.InvoiceType.Tutition,
                Status = Domain.Entities.InvoiceStatus.Outstanding
            },

        };
        return invoiceDTOList;
    }
    }

}
