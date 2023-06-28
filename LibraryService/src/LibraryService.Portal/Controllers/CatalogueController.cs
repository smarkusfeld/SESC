using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class CatalogueController : Controller
    {
        private readonly ICatalogueService _service;
        private readonly ILogger<CatalogueController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public CatalogueController(ILogger<CatalogueController> logger, CatalogueService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary> 
        /// Get All Books from library catalogue
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
        [HttpGet("add/book/{isbn}")]
        public async Task<IActionResult> Add(string isbn)
        {
            var response = await _service.AddBookByISBN(isbn);
            _logger.LogInformation($"New Book Added for ISBN {isbn}");
            return Ok(response);
        }

        
    }
}
