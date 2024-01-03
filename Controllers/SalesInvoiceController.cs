using Accounting_System.Data;
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
            sales.Customers = await _dbContext.Customers
                .OrderBy(c => c.Id)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
            sales.Products = await _dbContext.Products
                .OrderBy(p => p.Id)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();
            if (ModelState.IsValid)
            {
                var getLastNumber = await _salesInvoiceRepo.GetLastSeriesNumber();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(sales);
                }
                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Sales Invoice created successfully, Warning {totalRemainingSeries} series number remaining";
                }
                else
                {
                    TempData["success"] = "Sales Invoice created successfully";
                }

                var generateCRNo = await _salesInvoiceRepo.GenerateSINo();
                var existingCustomers = _dbContext.Customers
                                               .FirstOrDefault(si => si.Id == sales.CustomerId);

                sales.CustomerNo = existingCustomers.Number;
                sales.SeriesNumber = getLastNumber;
                sales.CreatedBy = _userManager.GetUserName(this.User);
                sales.SINo = generateCRNo;
                sales.Amount = sales.Quantity * sales.UnitPrice;
                if (sales.Amount >= sales.Discount)
                {
                    if (existingCustomers.CustomerType == "Vatable")
                    {
                        decimal netDiscount = (decimal)(sales.Amount - sales.Discount);
                        sales.NetDiscount = netDiscount;
                        sales.VatableSales = netDiscount / (decimal)1.12;
                        sales.VatAmount = netDiscount - sales.VatableSales;
                        if (existingCustomers.WithHoldingTax)
                        {
                            sales.WithHoldingTaxAmount = sales.VatableSales * (decimal)0.01;
                        }
                        if (existingCustomers.WithHoldingVat)
                        {
                            sales.WithHoldingVatAmount = sales.VatableSales * (decimal)0.05;
                        }
                    }
                    else if (existingCustomers.CustomerType == "Zero Rated")
                    {
                        decimal netDiscount = (decimal)(sales.Amount - sales.Discount);
                        sales.NetDiscount = netDiscount;
                        sales.ZeroRated = sales.Amount;

                        if (existingCustomers.WithHoldingTax)
                        {
                            sales.WithHoldingTaxAmount = sales.ZeroRated * (decimal)0.01;
                        }
                        if (existingCustomers.WithHoldingVat)
                        {
                            sales.WithHoldingVatAmount = sales.ZeroRated * (decimal)0.05;
                        }
                    }
                    else
                    {
                        decimal netDiscount = (decimal)(sales.Amount - sales.Discount);
                        sales.NetDiscount = netDiscount;
                        sales.VatExempt = sales.Amount;
                        if (existingCustomers.WithHoldingTax)
                        {
                            sales.WithHoldingTaxAmount = sales.VatExempt * (decimal)0.01;
                        }
                        if (existingCustomers.WithHoldingVat)
                        {
                            sales.WithHoldingVatAmount = sales.VatExempt * (decimal)0.05;
                        }
                    }
                    _dbContext.Add(sales);
                }
                else
                {
                    TempData["error"] = "Please input below or exact amount based on the Sales Invoice";
                    return View(sales);
                }

                #region --Audit Trail Recording

                AuditTrail auditTrail = new(sales.CreatedBy, $"Create new invoice# {sales.SINo}", "Sales Invoice");
                _dbContext.Add(auditTrail);

                #endregion --Audit Trail Recording

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

                if (ModelState.IsValid)
                {
                    existingModel.TransactionDate = model.TransactionDate;
                    existingModel.OtherRefNo = model.OtherRefNo;
                    existingModel.PoNo = model.PoNo;
                    existingModel.Quantity = model.Quantity;
                    existingModel.UnitPrice = model.UnitPrice;
                    existingModel.Remarks = model.Remarks;
                    existingModel.Discount = model.Discount;
                    existingModel.Amount = model.Quantity * model.UnitPrice;

                    if (existingModel.Amount >= model.Discount)
                    {
                        var existingCustomers = _dbContext.Customers
                                                       .FirstOrDefault(si => si.Id == existingModel.CustomerId);

                        if (existingCustomers.CustomerType == "Vatable")
                        {
                            decimal netDiscount = (decimal)(existingModel.Amount - model.Discount);
                            existingModel.NetDiscount = netDiscount;
                            existingModel.VatableSales = netDiscount / (decimal)1.12;
                            existingModel.VatAmount = netDiscount - existingModel.VatableSales;
                            if (existingCustomers.WithHoldingTax)
                            {
                                existingModel.WithHoldingTaxAmount = existingModel.VatableSales * (decimal)0.01;
                            }
                            if (existingCustomers.WithHoldingVat)
                            {
                                existingModel.WithHoldingVatAmount = existingModel.VatableSales * (decimal)0.05;
                            }
                        }
                        else if (existingCustomers.CustomerType == "Zero Rated")
                        {
                            decimal netDiscount = (decimal)(existingModel.Amount - model.Discount);
                            existingModel.NetDiscount = netDiscount;
                            existingModel.ZeroRated = existingModel.Amount;

                            if (existingCustomers.WithHoldingTax)
                            {
                                existingModel.WithHoldingTaxAmount = existingModel.ZeroRated * (decimal)0.01;
                            }
                            if (existingCustomers.WithHoldingVat)
                            {
                                existingModel.WithHoldingVatAmount = existingModel.ZeroRated * (decimal)0.05;
                            }
                        }
                        else
                        {
                            decimal netDiscount = (decimal)(existingModel.Amount - model.Discount);
                            existingModel.NetDiscount = netDiscount;
                            existingModel.VatExempt = existingModel.Amount;
                            if (existingCustomers.WithHoldingTax)
                            {
                                existingModel.WithHoldingTaxAmount = existingModel.VatExempt * (decimal)0.01;
                            }
                            if (existingCustomers.WithHoldingVat)
                            {
                                existingModel.WithHoldingVatAmount = existingModel.VatExempt * (decimal)0.05;
                            }
                        }

                        #region --Audit Trail Recording

                        var modifiedBy = _userManager.GetUserName(this.User);
                        AuditTrail auditTrail = new(modifiedBy, $"Edited invoice# {model.SINo}", "Sales Invoice");
                        _dbContext.Add(auditTrail);

                        #endregion --Audit Trail Recording
                    }
                    else
                    {
                        TempData["error"] = "Please input below or exact amount based unit price multiply quantity";
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The information you submitted is not valid!");
                    return View(model);
                }

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

                #region --Audit Trail Recording

                var printedBy = _userManager.GetUserName(this.User);
                AuditTrail auditTrail = new(printedBy, $"Printed original copy of invoice# {sales.SINo}", "Sales Invoice");
                _dbContext.Add(auditTrail);

                #endregion --Audit Trail Recording

                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("PrintInvoice", new { id = id });
        }

        public async Task<IActionResult> Post(int invoiceId)
        {
            var model = await _dbContext.SalesInvoices.FindAsync(invoiceId);

            if (model != null)
            {
                if (!model.IsPosted)
                {
                    model.IsPosted = true;

                    #region --Previous Implementation

                    //await _inventoryRepo.UpdateQuantity(model.Quantity, int.Parse(model.ProductNo));
                    //var ledgers = new Ledger[]
                    //  {
                    //    new Ledger {AccountNo = 1001,TransactionNo = model.SINo, TransactionDate = model.TransactionDate, Category = "Debit", CreatedBy = _userManager.GetUserName(this.User), Amount = model.Amount},
                    //    new Ledger {AccountNo = 2001,TransactionNo = model.SINo, TransactionDate = model.TransactionDate, Category = "Credit", CreatedBy = _userManager.GetUserName(this.User), Amount = model.VatAmount},
                    //    new Ledger {AccountNo = 4001,TransactionNo = model.SINo, TransactionDate = model.TransactionDate, Category = "Credit", CreatedBy = _userManager.GetUserName(this.User), Amount = model.VatableSales}
                    //  };
                    //_dbContext.Ledgers.AddRange(ledgers);

                    #endregion --Previous Implementation

                    #region --Sales Book Recording

                    var sales = new SalesBook();

                    if (model.CustomerType == "Vatable")
                    {
                        sales.TransactionDate = model.TransactionDate.ToShortDateString();
                        sales.SerialNo = model.SINo;
                        sales.SoldTo = model.SoldTo;
                        sales.TinNo = model.TinNo;
                        sales.Address = model.Address;
                        sales.Description = model.ProductName;
                        sales.Amount = model.Amount;
                        sales.VatAmount = model.VatAmount;
                        sales.VatableSales = model.VatableSales;
                        sales.Discount = model.Discount;
                        sales.NetSales = model.NetDiscount;
                        sales.CreatedBy = model.CreatedBy;
                        sales.CreatedDate = model.CreatedDate;
                    }
                    else if (model.CustomerType == "Exempt")
                    {
                        sales.TransactionDate = model.TransactionDate.ToShortDateString();
                        sales.SerialNo = model.SINo;
                        sales.SoldTo = model.SoldTo;
                        sales.TinNo = model.TinNo;
                        sales.Address = model.Address;
                        sales.Description = model.ProductName;
                        sales.Amount = model.Amount;
                        sales.VatExemptSales = model.Amount;
                        sales.Discount = model.Discount;
                        sales.NetSales = model.NetDiscount;
                        sales.CreatedBy = model.CreatedBy;
                        sales.CreatedDate = model.CreatedDate;
                    }
                    else
                    {
                        sales.TransactionDate = model.TransactionDate.ToShortDateString();
                        sales.SerialNo = model.SINo;
                        sales.SoldTo = model.SoldTo;
                        sales.TinNo = model.TinNo;
                        sales.Address = model.Address;
                        sales.Description = model.ProductName;
                        sales.Amount = model.Amount;
                        sales.ZeroRated = model.Amount;
                        sales.Discount = model.Discount;
                        sales.NetSales = model.NetDiscount;
                        sales.CreatedBy = model.CreatedBy;
                        sales.CreatedDate = model.CreatedDate;
                    }

                    _dbContext.Add(sales);

                    #endregion --Sales Book Recording

                    #region --General Ledger Book Recording

                    var ledgers = new List<GeneralLedgerBook>();

                    ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.TransactionDate.ToShortDateString(),
                            Reference = model.SINo,
                            Description = model.ProductName,
                            AccountTitle = "1010201 AR-Trade Receivable",
                            Debit = model.NetDiscount - (model.WithHoldingTaxAmount + model.WithHoldingVatAmount),
                            Credit = 0,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );

                    if (model.WithHoldingTaxAmount > 0)
                    {
                        ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.TransactionDate.ToShortDateString(),
                                Reference = model.SINo,
                                Description = model.ProductName,
                                AccountTitle = "1010202 Deferred Creditable Withholding Tax",
                                Debit = model.WithHoldingTaxAmount,
                                Credit = 0,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }
                    if (model.WithHoldingVatAmount > 0)
                    {
                        ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.TransactionDate.ToShortDateString(),
                                Reference = model.SINo,
                                Description = model.ProductName,
                                AccountTitle = "1010203 Deferred Creditable Withholding Vat",
                                Debit = model.WithHoldingVatAmount,
                                Credit = 0,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }
                    if (model.ProductName == "Biodiesel")
                    {
                        ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.TransactionDate.ToShortDateString(),
                                Reference = model.SINo,
                                Description = model.ProductName,
                                AccountTitle = "4010101 Sales - Biodiesel",
                                Debit = 0,
                                Credit = model.VatableSales > 0
                                            ? model.VatableSales
                                            : (model.ZeroRated + model.VatExempt) - model.Discount,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }
                    else if (model.ProductName == "Econogas")
                    {
                        ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.TransactionDate.ToShortDateString(),
                                Reference = model.SINo,
                                Description = model.ProductName,
                                AccountTitle = "4010102 Sales - Econogas",
                                Debit = 0,
                                Credit = model.VatableSales > 0
                                            ? model.VatableSales
                                            : (model.ZeroRated + model.VatExempt) - model.Discount,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }
                    else if (model.ProductName == "Envirogas")
                    {
                        ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.TransactionDate.ToShortDateString(),
                                Reference = model.SINo,
                                Description = model.ProductName,
                                AccountTitle = "4010103 Sales - Envirogas",
                                Debit = 0,
                                Credit = model.VatableSales > 0
                                            ? model.VatableSales
                                            : (model.ZeroRated + model.VatExempt) - model.Discount,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }

                    if (model.VatAmount > 0)
                    {
                        ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.TransactionDate.ToShortDateString(),
                                Reference = model.SINo,
                                Description = model.ProductName,
                                AccountTitle = "2010301 Vat Output",
                                Debit = 0,
                                Credit = model.VatAmount,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }

                    _dbContext.GeneralLedgerBooks.AddRange(ledgers);

                    #endregion --General Ledger Book Recording

                    #region --Audit Trail Recording

                    var postedBy = _userManager.GetUserName(this.User);
                    AuditTrail auditTrail = new(postedBy, $"Posted invoice# {model.SINo}", "Sales Invoice");
                    _dbContext.Add(auditTrail);

                    #endregion --Audit Trail Recording

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
    }
}