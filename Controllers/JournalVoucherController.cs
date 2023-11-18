using Microsoft.AspNetCore.Mvc;

namespace Accounting_System.Controllers
{
    public class JournalVoucherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
