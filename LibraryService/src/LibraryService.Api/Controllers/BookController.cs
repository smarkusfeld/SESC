using LibraryService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, IBookService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllBooks();
            int count = response.Count();
            return count == 0 ? BadRequest("No Books Found") : Ok(response);
        }

        /// <summary>
        /// Add Book to Library. If book already exists, a new copy is added
        /// </summary>
        /// <returns></returns>
        [HttpGet("{isbn}")]
        public async Task<IActionResult> Add(string isbn)
        {
            var response = await _service.ISBNCheck(isbn);
            return Ok(response);
        }

        /// <summary>
        /// Add Book to Library. If book already exists, a new copy is added
        /// </summary>
        /// <returns></returns>
        [HttpGet("add/{isbn}")]
        public async Task<IActionResult> check(string isbn)
        {
            var response = await _service.GetDetails(isbn);
        
            return Ok(response);
        }
    }
}
