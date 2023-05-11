using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

      

        /// <summary>
        /// Get the list of accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var accountDTOList = _service.GetAllAccounts().Result;
            return accountDTOList == null ? BadRequest() : Ok(accountDTOList);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var accountDTO = _service.GetAccountById(id);
            return accountDTO == null ? NotFound() : Ok(accountDTO);
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
        public IActionResult Remove(int id)
        {
            var existingItem = _service.GetAccountById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            var response = _service.DeleteAccount(id).Result;
            return response == true ? Ok() : BadRequest();
        }
    }
}
