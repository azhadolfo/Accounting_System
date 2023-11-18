using Microsoft.AspNetCore.Mvc;

namespace Accounting_System.Controllers
{
    public class DMCMController : Controller
    {
        public IActionResult DebitMemo()
        {
            return View();
        }

        public IActionResult CreditMemo()
        {
            return View();
        }
    }
}
