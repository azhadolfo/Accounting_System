using Microsoft.AspNetCore.Mvc;

namespace Accounting_System.Controllers
{
    public class ReceivingReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
