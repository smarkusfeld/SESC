using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using FinanceService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _service;
        public PaymentController(PaymentService service)
        {
            _service = service;
        }
        /// <summary>
        /// Make a payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPost("{reference}")]
        public IActionResult Pay(string reference, [FromBody] PaymentDTO paymentDTO)
        {
            var invoiceID = _service.FindInvoiceID(reference).Result;
            if (invoiceID == 0) { return BadRequest("Invoice Not Found"); }
            paymentDTO.InvoiceID = invoiceID;
            
            //add valiation logic
            if (!ModelState.IsValid)
            {
                var result = _service.MakePayment(paymentDTO).Result;
                return result == true ? Ok() : BadRequest();

            }
            return BadRequest(ModelState);
        }
        /// <summary>
        /// Cancel a payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPut("{reference}")]
        public IActionResult Cancel(string reference)
        {
            var payment = _service.FindPaymentByReference(reference).Result;
            if (payment != null && payment.Status == PaymentStatus.Recieved)
            {
                var result = _service.CancelPayment(payment).Result;
                return result == true ? Ok() : BadRequest();
            }
            return BadRequest("Payment Not Found");
        }
        /// <summary>
        /// Process a payment 
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPut("{reference}")]
        public IActionResult Process(string reference)
        {
            var payment = _service.FindPaymentByReference(reference).Result;
            if (payment != null && payment.Status == PaymentStatus.Recieved)
            {
                var result = _service.CancelPayment(payment).Result;
                return result == true ? Ok() : BadRequest();
            }
            return BadRequest("Payment Not Found");
        }

    }
}
