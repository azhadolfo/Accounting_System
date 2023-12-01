﻿using Accounting_System.Data;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Mvc;
using Accounting_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Accounting_System.Controllers
{
    [Authorize]
    public class SalesInvoiceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly SalesInvoiceRepo _salesInvoiceRepo;

        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly InventoryRepo _inventoryRepo;

        public SalesInvoiceController(ILogger<HomeController> logger, ApplicationDbContext dbContext, SalesInvoiceRepo salesInvoiceRepo, UserManager<IdentityUser> userManager, InventoryRepo inventoryRepo)
        {
            _dbContext = dbContext;
            _salesInvoiceRepo = salesInvoiceRepo;
            _logger = logger;
            this._userManager = userManager;
            _inventoryRepo = inventoryRepo;
        }

        public async Task<IActionResult> Index()
        {
            var salesInvoice = await _salesInvoiceRepo.GetSalesInvoicesAsync();

            return View(salesInvoice);
        }

        public async Task<IActionResult> Post(int invoiceId)
        {
            var model = await _dbContext.SalesInvoices.FindAsync(invoiceId);

            if (model != null)
            {
                if (!model.IsPosted)
                {
                    model.IsPosted = true;
                    //await _inventoryRepo.UpdateQuantity(model.Quantity, int.Parse(model.ProductNo));
                    //var ledgers = new Ledger[]
                    //  {
                    //    new Ledger {AccountNo = 1001,TransactionNo = model.SINo, TransactionDate = model.TransactionDate, Category = "Debit", CreatedBy = _userManager.GetUserName(this.User), Amount = model.Amount},
                    //    new Ledger {AccountNo = 2001,TransactionNo = model.SINo, TransactionDate = model.TransactionDate, Category = "Credit", CreatedBy = _userManager.GetUserName(this.User), Amount = model.VatAmount},
                    //    new Ledger {AccountNo = 4001,TransactionNo = model.SINo, TransactionDate = model.TransactionDate, Category = "Credit", CreatedBy = _userManager.GetUserName(this.User), Amount = model.VatableSales}
                    //  };
                    //_dbContext.Ledgers.AddRange(ledgers);
                    await _dbContext.SaveChangesAsync();
                    TempData["success"] = "Sales Invoice has been Posted.";
                }
                else
                {
                    model.IsVoid = true;
                    await _dbContext.SaveChangesAsync();
                    TempData["success"] = "Sales Invoice has been Voided.";
                }
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new SalesInvoice();
            viewModel.Customers = await _dbContext.Customers
                .OrderBy(c => c.Id)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
            viewModel.Products = await _dbContext.Products
                .OrderBy(p => p.Id)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesInvoice sales)
        {
            if (ModelState.IsValid)
            {
                var generateCRNo = await _salesInvoiceRepo.GenerateSINo();

                sales.SeriesNumber = await _salesInvoiceRepo.GetLastSeriesNumber();
                sales.CreatedBy = _userManager.GetUserName(this.User);
                sales.SINo = generateCRNo;
                sales.Amount = sales.Quantity * sales.UnitPrice;
                if (sales.CustomerType == "Vatable")
                {
                    decimal netDiscount = (decimal)(sales.Amount - sales.Discount);

                    sales.NetDiscount = netDiscount;
                    sales.VatableSales = netDiscount / (decimal)1.12;
                    sales.VatAmount = netDiscount - sales.VatableSales;
                }

                _dbContext.Add(sales);

                //Implementation of Audit trail
                //AuditTrail auditTrail = new(sales.CreatedBy, $"Create new invoice#{sales.SerialNo}", "Sales Invoice");
                //_dbContext.Add(auditTrail);

                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "The information you submitted is not valid!");
                return View(sales);
            }
        }

        [HttpGet]
        public JsonResult GetCustomerDetails(int customerId)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                return Json(new
                {
                    SoldTo = customer.Name,
                    Address = customer.Address,
                    TinNo = customer.TinNo,
                    BusinessStyle = customer.BusinessStyle,
                    Terms = customer.Terms,
                    CustomerType = customer.CustomerType,
                    WithHoldingTax = customer.WithHoldingTax
                    // Add other properties as needed
                });
            }
            return Json(null); // Return null if no matching customer is found
        }

        [HttpGet]
        public JsonResult GetProductDetails(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(c => c.Id == productId);
            if (product != null)
            {
                return Json(new
                {
                    ProductName = product.Name,
                    ProductUnit = product.Unit
                });
            }
            return Json(null); // Return null if no matching product is found
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var salesInvoice = await _salesInvoiceRepo.FindSalesInvoice(id);
                return View(salesInvoice);
            }
            catch (Exception ex)
            {
                // Handle other exceptions, log them, and return an error response.
                _logger.LogError(ex, "An error occurred.");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SalesInvoice model)
        {
            try
            {
                var existingModel = await _salesInvoiceRepo.FindSalesInvoice(model.Id);

                if (existingModel == null)
                {
                    return NotFound(); // Return a "Not Found" response when the entity is not found.
                }

                existingModel.TransactionDate = model.TransactionDate;
                existingModel.OtherRefNo = model.OtherRefNo;
                existingModel.PoNo = model.PoNo;
                existingModel.ProductNo = model.ProductNo;
                existingModel.Quantity = model.Quantity;
                existingModel.UnitPrice = model.UnitPrice;
                existingModel.Amount = model.Quantity * model.UnitPrice;
                existingModel.Remarks = model.Remarks;

                // Save the changes to the database
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect to a success page or the index page
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        public async Task<IActionResult> PrintInvoice(int id)
        {
            var sales = await _salesInvoiceRepo.FindSalesInvoice(id);
            return View(sales);
        }

        public async Task<IActionResult> PrintedInvoice(int id)
        {
            var sales = await _salesInvoiceRepo.FindSalesInvoice(id);
            if (sales != null && sales.OriginalCopy)
            {
                sales.OriginalCopy = false;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("PrintInvoice", new { id = id });
        }
    }
}