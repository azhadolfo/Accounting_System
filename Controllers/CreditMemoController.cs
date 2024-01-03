using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class CreditMemoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly CreditMemoRepo _creditMemoRepo;

        public CreditMemoController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, CreditMemoRepo creditMemoRepo)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _creditMemoRepo = creditMemoRepo;
        }

        public async Task<IActionResult> Index()
        {
            var cm = await _dbContext.CreditMemos
                .Include(cm => cm.SalesInvoice)
                .Include(cm => cm.StatementOfAccount)
                .OrderBy(cm => cm.Id)
                .ToListAsync();

            return View(cm);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new CreditMemo();
            viewModel.Invoices = await _dbContext.SalesInvoices
                .Select(si => new SelectListItem
                {
                    Value = si.Id.ToString(),
                    Text = si.SINo
                })
                .ToListAsync();
            viewModel.Soa = await _dbContext.StatementOfAccounts
                .Select(soa => new SelectListItem
                {
                    Value = soa.Id.ToString(),
                    Text = soa.SOANo
                })
                .ToListAsync();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreditMemo model)
        {
            if (ModelState.IsValid)
            {
                var getLastNumber = await _creditMemoRepo.GetLastSeriesNumber();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }
                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Credit Memo created successfully, Warning {totalRemainingSeries} series number remaining";
                }
                else
                {
                    TempData["success"] = "Credit Memo created successfully";
                }

                var generatedCM = await _creditMemoRepo.GenerateCMNo();
                
                model.SeriesNumber = getLastNumber;
                model.CMNo = generatedCM;
                model.CreatedBy = _userManager.GetUserName(this.User);

                if (model.Source == "Sales Invoice")
                {
                    model.SOAId = null;
                    model.SINo = await _creditMemoRepo.GetSINoAsync(model.SIId);

                    var existingSalesInvoice = _dbContext.SalesInvoices
                                               .FirstOrDefault(si => si.Id == model.SIId);

                    model.CreditAmount = existingSalesInvoice.Quantity * model.AdjustedPrice - existingSalesInvoice.Amount;

                    if (existingSalesInvoice.CustomerType == "Vatable")
                    {
                        model.VatableSales = model.CreditAmount / (decimal)1.12;
                        model.VatAmount = model.CreditAmount - model.VatableSales;
                        model.TotalSales = model.VatableSales + model.VatAmount;
                    }

                    model.TotalSales = model.CreditAmount;
                }
                else if (model.Source == "Statement Of Account")
                {
                    model.SIId = null;
                    model.SOANo = await _creditMemoRepo.GetSOANoAsync(model.SOAId);

                    var existingSoa = _dbContext.StatementOfAccounts
                        .Include(soa => soa.Customer)
                        .FirstOrDefault(soa => soa.Id == model.SOAId);

                    model.CreditAmount = model.AdjustedPrice - existingSoa.Amount;

                    if (existingSoa.Customer.CustomerType == "Vatable")
                    {
                        model.VatableSales = model.CreditAmount / (decimal)1.12;
                        model.VatAmount = model.CreditAmount - model.VatableSales;
                        model.TotalSales = model.VatableSales + model.VatAmount;
                    }

                    model.TotalSales = model.CreditAmount;
                }

                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The information you submitted is not valid!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbContext.CreditMemos == null)
            {
                return NotFound();
            }

            var creditMemo = await _dbContext.CreditMemos.FindAsync(id);
            if (creditMemo == null)
            {
                return NotFound();
            }

            creditMemo.Invoices = await _dbContext.SalesInvoices
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SINo
                })
                .ToListAsync();

            creditMemo.Soa = await _dbContext.StatementOfAccounts
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SOANo
                })
                .ToListAsync();

            return View(creditMemo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreditMemo model)
        {
            if (ModelState.IsValid)
            {
                var existingModel = await _dbContext.CreditMemos.FindAsync(model.Id);

                if (existingModel == null)
                {
                    return NotFound();
                }

                existingModel.Date = model.Date;
                existingModel.Source = model.Source;
                existingModel.Description = model.Description;
                existingModel.AdjustedPrice = model.AdjustedPrice;

                if (existingModel.Source == "Sales Invoice")
                {
                    existingModel.SOAId = null;
                    existingModel.SIId = model.SIId;

                    var existingSalesInvoice = _dbContext.SalesInvoices
                                               .FirstOrDefault(si => si.Id == existingModel.SIId);

                    existingModel.CreditAmount = existingSalesInvoice.Quantity * model.AdjustedPrice - existingSalesInvoice.Amount;

                    if (existingSalesInvoice.CustomerType == "Vatable")
                    {
                        existingModel.VatableSales = existingModel.CreditAmount / (decimal)1.12;
                        existingModel.VatAmount = existingModel.CreditAmount - existingModel.VatableSales;
                        existingModel.TotalSales = existingModel.VatableSales + existingModel.VatAmount;
                    }

                    existingModel.TotalSales = existingModel.CreditAmount;
                }
                else if (model.Source == "Statement Of Account")
                {
                    existingModel.SIId = null;
                    existingModel.SOAId = model.SOAId;

                    var existingSoa = _dbContext.StatementOfAccounts
                        .Include(soa => soa.Customer)
                        .FirstOrDefault(soa => soa.Id == existingModel.SOAId);

                    existingModel.CreditAmount = model.AdjustedPrice - existingSoa.Amount;

                    if (existingSoa.Customer.CustomerType == "Vatable")
                    {
                        existingModel.VatableSales = existingModel.CreditAmount / (decimal)1.12;
                        existingModel.VatAmount = existingModel.CreditAmount - existingModel.VatableSales;
                        existingModel.TotalSales = existingModel.VatableSales + existingModel.VatAmount;
                    }

                    existingModel.TotalSales = existingModel.CreditAmount;
                }

                await _dbContext.SaveChangesAsync();

                TempData["success"] = "Credit Memo updated successfully";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null || _dbContext.CreditMemos == null)
            {
                return NotFound();
            }

            var creditMemo = await _dbContext.CreditMemos
                .Include(cm => cm.SalesInvoice)
                .Include(cm => cm.StatementOfAccount)
                .ThenInclude(soa => soa.Customer)
                .Include(cm => cm.StatementOfAccount)
                .ThenInclude(soa => soa.Service)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (creditMemo == null)
            {
                return NotFound();
            }

            return View(creditMemo);
        }

        public async Task<IActionResult> Printed(int id)
        {
            var cm = await _dbContext.CreditMemos.FindAsync(id);
            if (cm != null && !cm.IsPrinted)
            {
                cm.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Print", new { id = id });
        }
    }
}