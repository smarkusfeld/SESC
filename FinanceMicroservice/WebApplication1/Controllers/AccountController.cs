
using FinanceMicroservice.Application.DTOs;
using FinanceMicroservice.Application.Interfaces;
using FinanceMicroservice.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace FinanceMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(AccountService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get the list of accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accountDTOList = await _service.GetAllAccounts();
            if (accountDTOList == null)
            {
                return NotFound();
            }
            return Ok(accountDTOList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var accountDTO = await _service.GetAccountById(id);

            if (accountDTO != null)
            {
                return Ok(accountDTO);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post(AccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
            {
                _service.CreateAccount(accountDTO);
                return CreatedAtAction("Get", new { id = accountDTO.ID }, accountDTO);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var existingItem = _service.GetAccountById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            await _service.DeleteAccount(id);
            return NoContent();
        }
    }

}