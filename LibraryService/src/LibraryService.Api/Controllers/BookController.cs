using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
