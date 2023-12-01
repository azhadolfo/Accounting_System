﻿using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class ReceivingReportController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly ReceivingReportRepo _receivingReportRepo;

        public ReceivingReportController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, ReceivingReportRepo receivingReportRepo)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _receivingReportRepo = receivingReportRepo;
        }

        public async Task<IActionResult> Index()
        {
            var rr = await _dbContext.ReceivingReports
                .Include(r => r.PurchaseOrder)
                .OrderBy(r => r.Id)
                .ToListAsync();

            return View(rr);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ReceivingReport();
            viewModel.PurchaseOrders = await _dbContext.PurchaseOrders
                .Where(po => !po.IsReceived)
                .Select(po => new SelectListItem
                {
                    Value = po.Id.ToString(),
                    Text = po.PONo
                })
                .ToListAsync();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceivingReport model)
        {
            if (ModelState.IsValid)
            {
                var generatedRR = await _receivingReportRepo.GenerateRRNo();
                model.SeriesNumber = await _receivingReportRepo.GetLastSeriesNumber();
                model.RRNo = generatedRR;
                model.CreatedBy = _userManager.GetUserName(this.User);

                model.GainOrLoss = model.QuantityDelivered - model.QuantityReceived;

                _dbContext.Add(model);

                // Purchase Order process
                var po = await _dbContext.PurchaseOrders
                    .FirstOrDefaultAsync(po => po.Id == model.POId);

                if (po == null)
                {
                    return NotFound();
                }

                po.QuantityReceived += model.QuantityReceived;

                if (po.QuantityReceived >= po.Quantity)
                {
                    po.IsReceived = true;
                    po.ReceivedDate = DateTime.Now;
                }

                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Receiving Report created successfully";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The information you submitted is not valid!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbContext.ReceivingReports == null)
            {
                return NotFound();
            }

            var receivingReport = await _dbContext.ReceivingReports.FindAsync(id);
            if (receivingReport == null)
            {
                return NotFound();
            }

            receivingReport.PurchaseOrders = await _dbContext.PurchaseOrders
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.PONo
                })
                .ToListAsync();

            return View(receivingReport);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReceivingReport model)
        {
            if (ModelState.IsValid)
            {
                var existingModel = await _dbContext.ReceivingReports.FindAsync(model.Id);

                if (existingModel == null)
                {
                    return NotFound();
                }

                existingModel.Date = model.Date;
                existingModel.POId = model.POId;
                existingModel.TruckOrVessels = model.TruckOrVessels;
                existingModel.QuantityDelivered = model.QuantityDelivered;
                existingModel.QuantityReceived = model.QuantityReceived;
                existingModel.OtherRef = model.OtherRef;
                existingModel.Remarks = model.Remarks;

                await _dbContext.SaveChangesAsync();

                TempData["success"] = "Receiving Report updated successfully";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null || _dbContext.ReceivingReports == null)
            {
                return NotFound();
            }

            var receivingReport = await _dbContext.ReceivingReports
                .Include(r => r.PurchaseOrder)
                .ThenInclude(p => p.Supplier)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (receivingReport == null)
            {
                return NotFound();
            }

            return View(receivingReport);
        }

        public async Task<IActionResult> Printed(int id)
        {
            var rr = await _dbContext.ReceivingReports.FindAsync(id);
            if (rr != null && !rr.IsPrinted)
            {
                rr.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Print", new { id = id });
        }
    }
}