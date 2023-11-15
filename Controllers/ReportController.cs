using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_System.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ReportRepo _reportRepo;

        public ReportController(ApplicationDbContext dbContext, ReportRepo reportRepo)
        {
            _dbContext = dbContext;
            _reportRepo = reportRepo;
        }

        public IActionResult SalesBook()
        {
            return View();
        }

        public async Task<IActionResult> SalesBookReport(SalesBook model)
        {
            ViewBag.DateFrom = model.DateFrom;
            ViewBag.DateTo = model.DateTo;
            if (ModelState.IsValid)
            {
                try
                {
                    var salesBook = await _reportRepo.GetSalesBooksAsync(model.DateFrom, model.DateTo);

                    return View(salesBook);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction(nameof(SalesBook));
                }
            }

            return View(model);
        }

        public IActionResult CollectionReceiptBook()
        {
            return View();
        }

        public async Task<IActionResult> CollectionReceiptBookReport(CollectionReceiptBook model)
        {
            ViewBag.DateFrom = model.DateFrom;
            ViewBag.DateTo = model.DateTo;
            if (ModelState.IsValid)
            {
                try
                {
                    var collectionReceipts = await _reportRepo.GetCollectionReceiptBookAsync(model.DateFrom, model.DateTo);

                    return View(collectionReceipts);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction(nameof(CollectionReceiptBook));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> CustomerProfile()
        {
            var customers = await _reportRepo.GetCustomersAsync();

            return View(customers);
        }

        public async Task<IActionResult> ProductList()
        {
            var products = await _reportRepo.GetProductsAsync();

            return View(products);
        }
    }
}