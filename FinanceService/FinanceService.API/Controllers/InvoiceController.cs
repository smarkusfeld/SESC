using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.API.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;
        public InvoiceController(InvoiceService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get the list of invoices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoiceDTOList = await _service.GetAllInvoices();
            if (invoiceDTOList == null)
            {
                return NotFound();
            }
            return Ok(invoiceDTOList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        [HttpPost]
        public IActionResult Post(InvoiceDTO invoiceDTO)
        {
            if (!ModelState.IsValid)
            {
                _service.CreateInvoice(invoiceDTO);
                return CreatedAtAction("Get", new { id = invoiceDTO.ID }, invoiceDTO);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var existingItem = _service.GetInvoiceById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            await _service.DeleteInvoice(id);
            return NoContent();
        }
    }
}
