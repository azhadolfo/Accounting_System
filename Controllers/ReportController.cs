﻿using Accounting_System.Data;
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
    }
}