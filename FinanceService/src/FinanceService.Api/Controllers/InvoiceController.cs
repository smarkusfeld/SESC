using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using FinanceService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;
        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AccountDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var invoiceDTOList = _service.GetAllInvoices().Result;
            return invoiceDTOList == null ? BadRequest() : Ok(invoiceDTOList);
            
        }
        /// <summary>
        /// Find an invoice by passing the account id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns><seealso cref="IActionResult"/></returns> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var invoiceDTO = await _service.GetInvoiceById(id);

            if (invoiceDTO != null)
            {
                return Ok(invoiceDTO);
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Create a new invoice 
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            //add valiation logic
            if (!ModelState.IsValid)
            {
                _service.CreateInvoice(invoiceDTO);
                return Ok(invoiceDTO);

            }
            return BadRequest(ModelState);
        }
        /// <summary>
        /// Cancel an invoice 
        /// </summary>
        /// <param name="reference"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPut("[action]/{reference}")]
        public IActionResult Cancel(string reference)
        {
            var invoice = _service.GetInvoiceByReference(reference).Result;
            if (invoice != null && invoice.Status == InvoiceStatus.Outstanding)
            {
                invoice.Status = InvoiceStatus.Cancelled;
                var result = _service.UpdateInvoice(invoice).Result;
                return result == true ? Ok() : BadRequest();
            }
            return BadRequest();
        }
        
    }
}
