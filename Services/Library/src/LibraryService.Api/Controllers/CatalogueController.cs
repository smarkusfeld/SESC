using LibraryService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    /// <summary>
    /// Controller for all book logic 
    /// </summary>
    [Route("api/[controller]")]
    public class CatalogueController : Controller
    {
        private readonly ICatalogueService _service;
        private readonly ILogger<CatalogueController> _logger;

        /// <summary>
        /// Book Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public CatalogueController(ICatalogueService service, ILogger<CatalogueController> logger)
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
        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            _logger.LogInformation("Getting all books from database.");
            var response = await _service.GetAllBooks();
            _logger.LogInformation("Returned all books  from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }
        /// <summary> 
        /// Get All Books from library catalogue
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with book record <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no record exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the catalogue service returns a null task
        /// </returns>
        /// 
        [HttpGet("books/{isbn}")]
        public async Task<IActionResult> GetBookByISBN(string isbn)
        {
            _logger.LogInformation("Searching for book in database");
            var response = await _service.GetBook(isbn);
            _logger.LogInformation("Search complete");
            if (response == null) { return NotFound(); }
            return response !=null ? Ok(response) : NoContent();
        }

        /// <summary> 
        /// Get All Authors from Library Catalogue
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all records from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the catalogue service returns a null task
        /// </returns>
        /// 
        [HttpGet("authors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            _logger.LogInformation("Getting all authors from database.");
            var response = await _service.GetAllAuthors();
            _logger.LogInformation("Returned all authors  from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }

        /// <summary> 
        /// Get All Publishers from Library Catalogue
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all records from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the catalogue service returns a null task
        /// </returns>
        /// 
        [HttpGet("publishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            _logger.LogInformation("Getting all publishers from database.");
            var response = await _service.GetAllPublishers();
            _logger.LogInformation("Returned all publishers  from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }

        /// <summary> 
        /// Get All Subjects from Library Catalogue
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all records from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the catalogue service returns a null task
        /// </returns>
        /// 
        [HttpGet("subjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            _logger.LogInformation("Getting all subjects from database.");
            var response = await _service.GetAllSubjects();
            _logger.LogInformation("Returned all subjects from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }
    }
}