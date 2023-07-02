using Azure;
using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using FinanceService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace FinanceService.Api.Controllers
{
    /// <summary>
    /// Controller for all invoice logic
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;

        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(IInvoiceService service, ILogger<InvoiceController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>A collection of invoices or bad request response</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAllInvoices();
                int count = response.Count();
                return count == 0 ? BadRequest("No Records Found") : Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the GetAll action: " + ex);
                return StatusCode(500, "Internal server error");
            }

        }
        /// <summary>
        /// Find an invoice by passing the account id
        /// </summary>
        /// <param name="id">account id</param>
        /// <returns>Invoice Record</returns> 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _service.GetInvoiceById(id);
                return response == null ? NotFound() : Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the Get action: " + ex);
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Create a new invoice 
        /// </summary>
        /// <param name="invoiceDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] InvoiceDTO invoiceDTO)
        {
            //add valiation logic
            if (invoiceDTO == null) { return BadRequest("Invoice object is null"); }
            if(!ModelState.IsValid) { return BadRequest("Invalid Invoice Object"); }
            var check = await _service.ReferenceCheck(invoiceDTO.Reference);
            if(check) { return BadRequest("Invoice Reference Must Be Unique"); }
            try
            {
                var response = await _service.CreateInvoice(invoiceDTO);
                return response == true
                   ? Ok(invoiceDTO)
                   : BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the CreateInvoice action: " + ex);
                return StatusCode(500, "Internal server error");
            }
           
        }
        /// <summary>
        /// Cancel an invoice 
        /// </summary>
        /// <param name="reference"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPut("cancel/{reference}")]
        public async Task<IActionResult> Cancel(string reference)
        {
            try
            {
                var invoice = await _service.GetInvoiceByReference(reference);
                if (invoice == null)
                {
                    return BadRequest("Invoice Not Found");
                }
                else
                {
                    try
                    {
                        var result = await _service.CancelInvoice(invoice);
                        return result == true ? Ok() : BadRequest();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Something went wrong inside the Cancel invoice action:  " + ex);
                        return StatusCode(500, "Internal server error");
                    }
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError("Something went wrong inside the GetInvoiceByReference action: "  + ex);
                return StatusCode(500, "Internal server error");
            }
        }

    }
        
}

