using FinanceService.Application.DTOs;
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Api.Controllers
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


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AccountDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var request = _service.GetAllAccounts();
            var accountDTOList = request.Result;
            return accountDTOList == null ? BadRequest() : Ok(accountDTOList);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var accountDTO = _service.GetAccountById(id).Result;
            return accountDTO == null ? NotFound() : Ok(accountDTO);
        }
        [HttpGet("{student}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStudentAccount(string studentId)
        {
            var accountDTO = _service.GetStudentAccount(studentId).Result;
            return accountDTO == null ? NotFound("Account Does Not Exist") : Ok(accountDTO);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostAccount(string studentId)
        {
            
             var result = _service.CreateAccount(studentId).Result;
             return result == true ? Ok() : BadRequest();
        }
        [HttpPost]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var existingItem = _service.GetAccountById(id);
            if (existingItem == null)
            {
                return NotFound("Account Does Not Exist");
            }
            var response = _service.DeleteAccount(id).Result;
            return response == true ? Ok() : BadRequest();
        }
    }
}
