using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
