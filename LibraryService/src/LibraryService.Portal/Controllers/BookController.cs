using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Models;
using LibraryService.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MySqlX.XDevAPI.Common;

namespace LibraryService.Api.Controllers
{
    /// <summary>
    /// Controller for all book logic 
    /// </summary>
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly ICatalogueService _service;
        private readonly ILogger<BookController> _logger;

        /// <summary>
        /// Book Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public BookController(ILogger<BookController> logger, CatalogueService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary> 
        /// Get All Books from library catalogue
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all books from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the catalogue service returns a null task
        /// </returns>
        /// 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all books from database.");
            var response = await _service.GetAllBooks();
            _logger.LogInformation("Returned all books  from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }

        /// <summary>
        /// Add Book to Library. If book already exists, a new copy is added
        /// </summary>
        /// <returns> 
        /// A 201 status code produced by the <seealso cref="CreatedAtActionResult"/> with the new or updated book record<br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if the book record was not created<br/> 
        /// </returns>        
        [HttpGet("add/{isbn}")]
        public async Task<IActionResult> AddBook(string isbn)
        {
            _logger.LogInformation("Adding new book", isbn);
            var response = await _service.AddBookByISBN(isbn);
            _logger.LogInformation("New Book Added", isbn);
            return response != null
                ? CreatedAtAction(nameof(AddBook), response)
                : BadRequest();
        }

        
    }
}
