using Microsoft.AspNetCore.Mvc;

namespace Accounting_System.Controllers
{
    public class CheckVoucherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}