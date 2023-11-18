using Microsoft.AspNetCore.Mvc;

namespace Accounting_System.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
