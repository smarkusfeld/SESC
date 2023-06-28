using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Models;
using LibraryService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/library")]
    public class TransactionController : Controller
    {
        private readonly ILoanService _service;
        private readonly ILogger<TransactionController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public TransactionController(ILogger<TransactionController> logger, LoanService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Create new loan
        /// </summary>
        /// <returns></returns>
        [HttpGet("borrow/isbn")]
        public async Task<IActionResult> NewLoan([FromBody] AccountDTO account, string isbn)
        {
            var response = await _service.CreateLoan(account.AccountId, isbn, account.Pin, 14);
            _logger.LogInformation($"New Loan created for Book {isbn}");
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [HttpGet("return/isbn")]
        public async Task<IActionResult> ReturnLoan([FromBody] AccountDTO account, string isbn)
        {
            var response = await _service.CreateLoan(account.AccountId, isbn, account.Pin, 14);
            _logger.LogInformation($"{isbn} loan Returned for account {account.AccountId}.");
            return Ok(response);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("renew/isbn")]
        public async Task<IActionResult> RenewLoan([FromBody] AccountDTO account, string isbn)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("loans/active")]
        public async Task<IActionResult> GetAllActiveLoans()
        {
            var response = await _service.GetAllActiveLoans();
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("loans/overdue")]
        public async Task<IActionResult> GetAllOverdueLoans()
        {
            var response = await _service.GetAllOverdueLoans();
            return Ok(response);
        }
    }
}
