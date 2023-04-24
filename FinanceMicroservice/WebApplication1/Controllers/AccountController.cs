using FinanceMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FinanceMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IFinanceService _service;
        public AccountController(IFinanceService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var accounts = _service.GetAll();
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var account = _service.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Account value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var existingItem = _service.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return NoContent();
        }
    }