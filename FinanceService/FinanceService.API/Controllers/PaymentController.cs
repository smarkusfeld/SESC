using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _service;
        public PaymentController(PaymentService service)
        {
            _service = service;
        }
      
        [HttpPost]
        public IActionResult Post(PaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                _service.MakePayment(paymentDTO);
                return CreatedAtAction("Get", new { id = paymentDTO.ID }, paymentDTO);

            }
            return BadRequest(ModelState);
        }
       
    }
}
