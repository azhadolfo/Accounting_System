using Accounting_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _dbContext
                .Inventories
                .Include(inventory => inventory.Product)
                .ToListAsync();

            return View(result);
        }
    }
}