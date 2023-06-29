using LibraryService.Api.Controllers;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Models;
using LibraryService.Application.Services;
using LibraryService.Domain.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.UnitTests
{
    public class BookControllerTest
    {
        private readonly Mock<ICatalogueService> catalogueService;
        private readonly Mock<ILogger<BookController>> logger;
        public BookControllerTest()
        {
            catalogueService = new Mock<ICatalogueService>();
            logger = new Mock<ILogger<BookController>>();
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            //arrange
            var bookDTOs = GetbookDTOList();
            catalogueService.Setup(x => x.GetAllBooks())
               .ReturnsAsync(bookDTOs);
            var bookController = new BookController(catalogueService.Object, logger.Object);
            //act
            var result = await bookController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
        }
        [Fact]
        public async Task GetAll_TaskResultDTOList()
        {
            //arrange
            var bookDTOs = GetbookDTOList();
            catalogueService.Setup(x => x.GetAllBooks())
                .ReturnsAsync(bookDTOs);
            var bookController = new BookController(catalogueService.Object, logger.Object);
            //act
            var result = await bookController.GetAll();
            var actionResult = result as OkObjectResult;

            //assert
            Assert.IsType<List<BookDTO>>(actionResult.Value);
            Assert.Equal(bookDTOs, actionResult.Value);
        }
        [Fact]        
        public async Task GetAll_ReturnsNoContent()
        {
            //arrange
            var bookDTOs = Enumerable.Empty<BookDTO>();
            catalogueService.Setup(x => x.GetAllBooks())
               .ReturnsAsync(bookDTOs);
            var bookController = new BookController(catalogueService.Object, logger.Object);
            //act
            var result = await bookController.GetAll();
            var actionResult = result as NoContentResult;

            //assert
            Assert.NotNull(actionResult);
            Assert.IsType<NoContentResult>(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }
        private static IEnumerable<BookDTO> GetbookDTOList()
        {
            IEnumerable<BookDTO> bookDTOList = new List<BookDTO>
        {
            new BookDTO
            {},
             new BookDTO
            {},
             new BookDTO
            {},
        };
            return bookDTOList;
        }
    }
}
