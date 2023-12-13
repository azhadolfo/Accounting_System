using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class DebitMemoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly DebitMemoRepo _debitMemoRepo;

        public DebitMemoController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, DebitMemoRepo dmcmRepo)
        {
            _dbContext = dbContext;
            this._userManager = userManager;
            _debitMemoRepo = dmcmRepo;
        }

        public async Task<IActionResult> Index()
        {
            var dm = await _dbContext.DebitMemos
                .Include(dm => dm.SalesInvoice)
                .Include(dm => dm.SOA)
                .OrderBy(dm => dm.Id)
                .ToListAsync();
            return View(dm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new DebitMemo();
            viewModel.SalesInvoices = _dbContext.SalesInvoices
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SINo
                })
                .ToList();
            viewModel.StatementOfAccounts = _dbContext.StatementOfAccounts
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SOANo
                })
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DebitMemo model)
        {
            if (ModelState.IsValid)
            {
                var generateDMNo = await _debitMemoRepo.GenerateDMNo();
                long getLastNumber = await _debitMemoRepo.GetLastSeriesNumber();

                model.SeriesNumber = getLastNumber;
                model.DMNo = generateDMNo;

                if (model.Source == "Sales Invoice")
                {
                    model.SOAId = null;

                    var existingSalesInvoice = _dbContext.SalesInvoices
                                               .FirstOrDefault(si => si.Id == model.SalesInvoiceId);

                    model.DebitAmount = model.AdjustedPrice * existingSalesInvoice.Quantity - existingSalesInvoice.Amount;

                    if (existingSalesInvoice.CustomerType == "Vatable")
                    {
                        model.VatableSales = model.DebitAmount / (decimal)1.12;
                        model.VatAmount = model.DebitAmount - model.VatableSales;
                        model.TotalSales = model.VatableSales + model.VatAmount;
                    }

                    model.TotalSales = model.DebitAmount;
                }
                else if (model.Source == "Statement Of Account")
                {
                    model.SalesInvoiceId = null;

                    var existingSoa = _dbContext.StatementOfAccounts
                        .Include(soa => soa.Customer)
                        .FirstOrDefault(soa => soa.Id == model.SOAId);

                    model.DebitAmount = model.AdjustedPrice - existingSoa.Amount;

                    if (existingSoa.Customer.CustomerType == "Vatable")
                    {
                        model.VatableSales = model.DebitAmount / (decimal)1.12;
                        model.VatAmount = model.DebitAmount - model.VatableSales;
                        model.TotalSales = model.VatableSales + model.VatAmount;
                    }

                    model.TotalSales = model.DebitAmount;
                }

                model.CreatedBy = _userManager.GetUserName(this.User);
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }

                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = "Debit Memo created successfully, Warning 100 series number remaining";
                }
                else
                {
                    TempData["success"] = "Debit Memo created successfully";
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "The information you submitted is not valid!");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Print(int? id)
        {
            if (id == null || _dbContext.DebitMemos == null)
            {
                return NotFound();
            }

            var debitMemo = await _dbContext.DebitMemos
                .Include(dm => dm.SalesInvoice)
                .Include(dm => dm.SOA)
                .ThenInclude(soa => soa.Customer)
                .Include(dm => dm.SOA)
                .ThenInclude(soa => soa.Service)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (debitMemo == null)
            {
                return NotFound();
            }
            return View(debitMemo);
        }

        public async Task<IActionResult> PrintedDM(int id)
        {
            var findIdOfDM = await _debitMemoRepo.FindDM(id);
            if (findIdOfDM != null && !findIdOfDM.IsPrinted)
            {
                findIdOfDM.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Print", new { id = id });
        }
    }
}