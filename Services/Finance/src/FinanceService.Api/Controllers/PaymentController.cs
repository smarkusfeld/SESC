using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using FinanceService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Api.Controllers
{
    /// <summary>
    /// Controller for all payment logic
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _service;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(PaymentService service, ILogger<PaymentController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Make a payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPost("{reference}")]
        public async Task<IActionResult> Pay(string reference, [FromBody] PaymentDTO paymentDTO)
        {
            //add valiation logic
            if (!ModelState.IsValid)
            {
                try
                {
                    var invoiceID = _service.GetInvoiceID(reference).Result;
                    if(invoiceID == 0) { return BadRequest("Invoice Not Found"); }
                    try
                    {
                        var result = _service.MakePayment(paymentDTO).Result;
                         return result == true ? Ok() : BadRequest();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Something went wrong inside the make payment action: " + ex);
                        return StatusCode(500, "Internal server error");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Something went wrong inside the GetInvoiceID action: " + ex);
                    return StatusCode(500, "Internal server error");
                }

            }
            return BadRequest(ModelState);
           
        }
        /// <summary>
        /// Cancel a payment
        /// </summary>
        /// <param name="reference"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPut("{reference}")]
        public async Task<IActionResult> Cancel(string reference)
        {
            try
            {
                var payment = await _service.FindPaymentByReference(reference);
                if (payment == null)
                {
                    return BadRequest("Payment Not Found");
                }                
                else
                {
                    try
                    {
                        var result = await _service.CancelPayment(payment);
                        return result == true ? Ok() : BadRequest();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Something went wrong inside the Cancel payment action:  " + ex);
                        return StatusCode(500, "Internal server error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the FindPaymentByReference action: " + ex);
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Process a payment 
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns><seealso cref="IActionResult"/></returns>
        [HttpPut("{reference}")]
        public async Task<IActionResult> Process(string reference)
        {
            try
            {
                var payment = await _service.FindPaymentByReference(reference);
                if (payment == null)
                {
                    return BadRequest("Payment Not Found");
                }
                else
                {
                    try
                    {
                        var result = await _service.ProcessPayment(payment);
                        return result == true ? Ok() : BadRequest();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Something went wrong inside the Process payment action:  " + ex);
                        return StatusCode(500, "Internal server error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside the FindPaymentByReference action: " + ex);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
