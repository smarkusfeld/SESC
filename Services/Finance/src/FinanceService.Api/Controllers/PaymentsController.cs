using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Reflection.Metadata.Ecma335;

namespace FinanceService.Api.Controllers
{
    /// <summary>
    /// Controller for all payment logic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _service;
        private readonly ILogger<PaymentsController> _logger;

        /// <summary>
        /// Payment Controller Constructor. 
        /// Defines the required logger and service interfaces 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public PaymentsController(IPaymentService service, ILogger<PaymentsController> logger)
        {

            _service = service;
            _logger = logger;
        }

        
        /// <summary>
        /// Make a New Payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns></returns>
        [HttpPost("pay")]
        public async Task<IActionResult> NewPayment(PaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                var result = await _service.MakePayment(paymentDTO);
                return result ? Ok("Payment Sucessful") : BadRequest();

            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Get All Payments To Be Processed
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns></returns>
        [HttpGet("process")]
        public async Task<IActionResult> GetPayementsToBeProcessed()
        {
            var payments = await _service.PaymentsToBeProcessed();
            return payments != null
                ? Ok(payments) : BadRequest();
        }

        /// <summary>
        /// Process Single Payment
        /// </summary>
        /// <param name="paymentDTO"></param>
        /// <returns></returns>
        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(PaymentDTO paymentDTO)
        {
            var result = await _service.ProcessPayment(paymentDTO);
            return result ? Ok("Payment Processed") : BadRequest();
        }

        
    }
}
