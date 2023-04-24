using Microsoft.AspNetCore.Mvc;

namespace FinanceMicroservice.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
