using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Models;
using LibraryService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    /// <summary>
    /// Controller for all loan logic 
    /// </summary>
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private readonly ILoanService _service;
        private readonly ILogger<LoansController> _logger;

        /// <summary>
        /// Loan Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public LoansController(ILogger<LoansController> logger, LoanService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Create new book loan using isbn
        /// </summary>
        /// <returns> 
        /// A 201 status code produced by the <seealso cref="CreatedAtActionResult"/> with the new or updated book record<br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if the book record was not created<br/> 
        /// </returns>  
        [HttpGet("borrow/{isbn}")]
        public async Task<IActionResult> NewLoan([FromBody] AccountDTO account, string isbn)
        {
            _logger.LogInformation("Create new loan", isbn);
            var response = await _service.CreateLoan(account.AccountId, isbn, account.Pin, 14);
            _logger.LogInformation("Loan created for", isbn);
            return response != null
                ? CreatedAtAction(nameof(NewLoan), response)
                : BadRequest();
        }
        /// <summary>
        /// Return book using isbn
        /// </summary>
        /// <param name="account"></param>
        /// <param name="isbn"></param>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the completed loan record<br/> 
        /// A 400 status code prodeced by the <seealso cref="BadRequestResult"/> if the loan was not reutned <br/> 
        [HttpGet("return/{isbn}")]
        public async Task<IActionResult> Return([FromBody] AccountDTO account, string isbn)
        {
            _logger.LogInformation("Returning Book for", isbn);
            var response = await _service.ReturnBook(account.AccountId, isbn, account.Pin);
            _logger.LogInformation("Returning Book for", isbn);
            return response != null
                ? Ok(response)
                : BadRequest();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("renew/{isbn}")]
        public async Task<IActionResult> RenewLoan([FromBody] AccountDTO account, string isbn)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Display all books currently on loan
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all active loans from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the loan service returns a null task
        /// </returns>
        [HttpGet("loans/active")]
        public async Task<IActionResult> GetAllActiveLoans()
        {
            _logger.LogInformation("Getting all active loans from database.");
            var response = await _service.GetAllActiveLoans();
            _logger.LogInformation("Returned all active loans from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }
        /// <summary>
        /// Display all overdue book loans
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all active loans from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the loan service returns a null task
        /// </returns>
        [HttpGet("loans/overdue")]
        public async Task<IActionResult> GetAllOverdueLoans()
        {
            _logger.LogInformation("Getting all overdue loans from database.");
            var response = await _service.GetAllOverdueLoans();
            _logger.LogInformation("Returned all overdue loans from database.");
            if (response == null) { return NotFound(); }
            return response.Any() ? Ok(response) : NoContent();
        }
    }
}
