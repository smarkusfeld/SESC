using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Api.Controllers
{
    /// <summary>
    /// Controller for all invoice logic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _service;
        private readonly ILogger<InvoicesController> _logger;
        /// <summary>
        /// Account Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public InvoicesController(IInvoiceService service, ILogger<InvoicesController> logger)
        {

            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get All Invoices
        /// </summary>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all invoice records from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no  invoice records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the  invoice recordsservice returns a null task
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoiceDTOList = await _service.GetAllInvoices();
            if (invoiceDTOList == null) { return NotFound(); }
            return invoiceDTOList.Any() ? Ok(invoiceDTOList) : NoContent();
        }


        /// <summary>
        /// Get All Invoices
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns> 
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with all invoice records from the database <br/> 
        /// A 204 status code prodeced by the <seealso cref="NoContentResult"/> if no  invoice records exists in the database <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if the  invoice recordsservice returns a null task
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAcccountInvoices(string id) 
        {
            var invoiceDTOList = await _service.GetAllInvoices(id);
            if (invoiceDTOList == null) { return NotFound(); }
            return invoiceDTOList.Any() ? Ok(invoiceDTOList) : NoContent();
        }



        /// <summary>
        /// Find Invoice by Reference
        /// </summary>
        /// <param name="reference"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> with the invoice <br/> 
        /// A 404 status code produced by the <seealso cref="NotFoundResult"/> if no invoice matched reference
        /// </returns>
        [HttpGet("find/{reference}")]
        public async Task<IActionResult> FindInvoice(string reference)
        {
            var invoiceDTO = await _service.GetInvoiceByReference(reference);
            return invoiceDTO == null ? NotFound() : Ok(invoiceDTO);
        }


        /// <summary>
        /// Create a new invoice
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> if invoice was created <br/> 
        /// A 400 status code produced by the <seealso cref="BadRequestResult"/> if the invoice could not be created <br/> 
        [HttpPost("library")]
        public async Task<IActionResult> CreateBookFeeInvoice(NewInvoiceDTO invoiceDTO)
        {
            _logger.LogInformation("Creating new library invoice.");
            var result = await _service.CreateLibraryInvoice(invoiceDTO);
            return result == null ? BadRequest() : Ok($"Invoice Reference:{result}");
        }

        /// <summary>
        /// Create An Invoice for a Library Fine
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> if invoice was created <br/> 
        /// A 400 status code produced by the <seealso cref="BadRequestResult"/> if the invoice could not be created <br/> 

        [HttpPost("student")]
        public async Task<IActionResult> CreateTutitionInvoice(NewInvoiceDTO invoiceDTO)
        {
            _logger.LogInformation("Creating new library invoice.");
            var result = await _service.CreateLibraryInvoice(invoiceDTO);
            return result == null ? BadRequest() : Ok($"Invoice Reference:{result}");
        }
        /// <summary>
        /// Cancel Invoice
        /// </summary>
        /// <param name=" reference"></param>
        /// <returns>
        /// A 200 status code produced by the <seealso cref="OkObjectResult"/> if invoice was canceled <br/> 
        /// A 400 status code produced by the <seealso cref="BadRequestResult"/> if the invoice was not canceled or found <br/> 
        /// </returns>
        [HttpPost("cancel/{reference}")]
        public async Task<IActionResult> Remove(string reference)
        {
            var result = await _service.CancelInvoice(reference);
            return result ? Ok("Invoice Canceled") : BadRequest();
        }
    }
}
