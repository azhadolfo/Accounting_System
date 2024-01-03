using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    [Authorize]
    public class ReceiptController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly ReceiptRepo _receiptRepo;

        public ReceiptController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, ReceiptRepo receiptRepo)
        {
            _dbContext = dbContext;
            this._userManager = userManager;
            _receiptRepo = receiptRepo;
        }

        public async Task<IActionResult> CollectionReceiptIndex()
        {
            var viewData = await _receiptRepo.GetCRAsync();

            return View(viewData);
        }

        public async Task<IActionResult> OfficialReceiptIndex()
        {
            var viewData = await _receiptRepo.GetORAsync();

            return View(viewData);
        }

        public IActionResult CreateCollectionReceipt()
        {
            var viewModel = new CollectionReceipt();

            viewModel.Customers = _dbContext.Customers
               .OrderBy(c => c.Id)
               .Select(s => new SelectListItem
               {
                   Value = s.Number.ToString(),
                   Text = s.Name
               })
               .ToList();

            viewModel.ChartOfAccounts = _dbContext.ChartOfAccounts
                .Where(coa => coa.Level == "4" || coa.Level == "5")
                .OrderBy(coa => coa.Id)
                .Select(s => new SelectListItem
                {
                    Value = s.Number,
                    Text = s.Number + " " + s.Name
                })
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollectionReceipt(CollectionReceipt model, string[] accountTitleText, decimal[] accountAmount, string[] accountTitle)
        {
            model.Customers = _dbContext.Customers
               .OrderBy(c => c.Id)
               .Select(s => new SelectListItem
               {
                   Value = s.Number.ToString(),
                   Text = s.Name
               })
               .ToList();

            model.Invoices = _dbContext.SalesInvoices
                .Where(si => !si.IsPaid && si.CustomerNo == model.CustomerNo)
                .OrderBy(si => si.Id)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SINo
                })
                .ToList();

            model.ChartOfAccounts = _dbContext.ChartOfAccounts
                .Where(coa => coa.Level == "4" || coa.Level == "5")
                .OrderBy(coa => coa.Id)
                .Select(s => new SelectListItem
                {
                    Value = s.Number,
                    Text = s.Number + " " + s.Name
                })
                .ToList();

            if (ModelState.IsValid)
            {
                #region --Validating the series

                var getLastNumber = await _receiptRepo.GetLastSeriesNumberCR();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }
                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Collection Receipt created successfully, Warning {totalRemainingSeries} series number remaining";
                }
                else
                {
                    TempData["success"] = "Collection Receipt created successfully";
                }

                #endregion --Validating the series

                #region --Saving default value

                var existingSalesInvoice = _dbContext.SalesInvoices
                                               .FirstOrDefault(si => si.Id == model.SalesInvoiceId);
                var generateCRNo = await _receiptRepo.GenerateCRNo();
                
                model.SeriesNumber = getLastNumber;
                model.SINo = existingSalesInvoice.SINo;
                model.CRNo = generateCRNo;
                model.CreatedBy = _userManager.GetUserName(this.User);
                model.Total = model.CashAmount + model.CheckAmount + model.ManagerCheckAmount + model.EWT + model.WVAT;

                decimal offsetAmount = 0;

                #endregion --Saving default value

                _dbContext.Add(model);

                #region --Audit Trail Recording

                AuditTrail auditTrail = new(model.CreatedBy, $"Create new collection receipt# {model.CRNo}", "Collection Receipt");
                _dbContext.Add(auditTrail);

                #endregion --Audit Trail Recording

                #region --General Ledger Book Recording

                var ledgers = new List<GeneralLedgerBook>();

                ledgers.Add(
                            new GeneralLedgerBook
                            {
                                Date = model.Date.ToShortDateString(),
                                Reference = model.CRNo,
                                Description = "Collection for Receivable",
                                AccountTitle = "1010101 Cash in Bank",
                                Debit = model.CashAmount + model.CheckAmount + model.ManagerCheckAmount,
                                Credit = 0,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );

                if (model.EWT > 0)
                {
                    ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.Date.ToShortDateString(),
                            Reference = model.CRNo,
                            Description = "Collection for Receivable",
                            AccountTitle = "1010604 Creditable Withholding Tax",
                            Debit = model.EWT,
                            Credit = 0,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                if (model.WVAT > 0)
                {
                    ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.Date.ToShortDateString(),
                            Reference = model.CRNo,
                            Description = "Collection for Receivable",
                            AccountTitle = "1010605 Creditable Withholding Vat",
                            Debit = model.WVAT,
                            Credit = 0,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                if (accountAmount.Length != 0 && accountTitleText.Length != 0)
                {
                    for (int i = 0; i < accountTitle.Length; i++)
                    {
                        ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.Date.ToShortDateString(),
                            Reference = model.CRNo,
                            Description = "Collection for Receivable",
                            AccountTitle = accountTitleText[i],
                            Debit = accountAmount[i],
                            Credit = 0,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                        );

                        offsetAmount += accountAmount[i];
                    }
                }

                ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.Date.ToShortDateString(),
                            Reference = model.CRNo,
                            Description = "Collection for Receivable",
                            AccountTitle = "1010201 AR-Trade Receivable",
                            Debit = 0,
                            Credit = model.CashAmount + model.CheckAmount + model.ManagerCheckAmount + offsetAmount,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );

                if (model.EWT > 0)
                {
                    ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.Date.ToShortDateString(),
                            Reference = model.CRNo,
                            Description = "Collection for Receivable",
                            AccountTitle = "1010202 Deferred Creditable Withholding Tax",
                            Debit = 0,
                            Credit = model.EWT,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                if (model.WVAT > 0)
                {
                    ledgers.Add(
                        new GeneralLedgerBook
                        {
                            Date = model.Date.ToShortDateString(),
                            Reference = model.CRNo,
                            Description = "Collection for Receivable",
                            AccountTitle = "1010203 Deferred Creditable Withholding Vat",
                            Debit = 0,
                            Credit = model.WVAT,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                _dbContext.AddRange(ledgers);

                #endregion --General Ledger Book Recording

                #region --Cash Receipt Book Recording

                var crb = new List<CashReceiptBook>();

                crb.Add(
                    new CashReceiptBook
                    {
                        Date = model.Date.ToShortDateString(),
                        RefNo = model.CRNo,
                        CustomerName = existingSalesInvoice.SoldTo,
                        Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                        CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                        COA = "1010101 Cash in Bank",
                        Particulars = existingSalesInvoice.SINo,
                        Debit = model.CashAmount + model.CheckAmount + model.ManagerCheckAmount,
                        Credit = 0,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate
                    }

                );

                if (model.EWT > 0)
                {
                    crb.Add(
                        new CashReceiptBook
                        {
                            Date = model.Date.ToShortDateString(),
                            RefNo = model.CRNo,
                            CustomerName = existingSalesInvoice.SoldTo,
                            Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                            CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                            COA = "1010604 Creditable Withholding Tax",
                            Particulars = existingSalesInvoice.SINo,
                            Debit = model.EWT,
                            Credit = 0,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                if (model.WVAT > 0)
                {
                    crb.Add(
                        new CashReceiptBook
                        {
                            Date = model.Date.ToShortDateString(),
                            RefNo = model.CRNo,
                            CustomerName = existingSalesInvoice.SoldTo,
                            Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                            CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                            COA = "1010605 Creditable Withholding Vat",
                            Particulars = existingSalesInvoice.SINo,
                            Debit = model.WVAT,
                            Credit = 0,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                if (accountAmount.Length != 0 && accountTitleText.Length != 0)
                {
                    for (int i = 0; i < accountTitle.Length; i++)
                    {
                        crb.Add(
                            new CashReceiptBook
                            {
                                Date = model.Date.ToShortDateString(),
                                RefNo = model.CRNo,
                                CustomerName = existingSalesInvoice.SoldTo,
                                Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                                CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                                COA = accountTitleText[i],
                                Particulars = existingSalesInvoice.SINo,
                                Debit = accountAmount[i],
                                Credit = 0,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = model.CreatedDate
                            }
                        );
                    }
                }

                crb.Add(
                new CashReceiptBook
                {
                    Date = model.Date.ToShortDateString(),
                    RefNo = model.CRNo,
                    CustomerName = existingSalesInvoice.SoldTo,
                    Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                    CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                    COA = "1010201 AR-Trade Receivable",
                    Particulars = existingSalesInvoice.SINo,
                    Debit = 0,
                    Credit = model.CashAmount + model.CheckAmount + model.ManagerCheckAmount + offsetAmount,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate
                }
                );

                if (model.EWT > 0)
                {
                    crb.Add(
                        new CashReceiptBook
                        {
                            Date = model.Date.ToShortDateString(),
                            RefNo = model.CRNo,
                            CustomerName = existingSalesInvoice.SoldTo,
                            Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                            CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                            COA = "1010202 Deferred Creditable Withholding Tax",
                            Particulars = existingSalesInvoice.SINo,
                            Debit = 0,
                            Credit = model.EWT,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                if (model.WVAT > 0)
                {
                    crb.Add(
                        new CashReceiptBook
                        {
                            Date = model.Date.ToShortDateString(),
                            RefNo = model.CRNo,
                            CustomerName = existingSalesInvoice.SoldTo,
                            Bank = model.CheckBank ?? (model.ManagerCheckBank != null ? model.ManagerCheckBank : "--"),
                            CheckNo = model.CheckNo ?? (model.ManagerCheckNo != null ? model.ManagerCheckNo : "--"),
                            COA = "1010203 Deferred Creditable Withholding Vat",
                            Particulars = existingSalesInvoice.SINo,
                            Debit = 0,
                            Credit = model.WVAT,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = model.CreatedDate
                        }
                    );
                }

                _dbContext.AddRange(crb);

                #endregion --Cash Receipt Book Recording

                await _receiptRepo.UpdateInvoice(existingSalesInvoice.Id, model.Total, offsetAmount);

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("CollectionReceiptIndex");
            }
            else
            {
                TempData["error"] = "The information you submitted is not valid!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult CreateOfficialReceipt()
        {
            var viewModel = new OfficialReceipt();
            viewModel.SOANo = _dbContext.StatementOfAccounts
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SOANo
                })
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfficialReceipt(OfficialReceipt model)
        {
            model.SOANo = _dbContext.StatementOfAccounts
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SOANo
                })
                .ToList();
            if (ModelState.IsValid)
            {
                var getLastNumber = await _receiptRepo.GetLastSeriesNumberOR();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }
                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Official Receipt created successfully, Warning {totalRemainingSeries} series number remaining";
                }
                else
                {
                    TempData["success"] = "Official Receipt created successfully";
                }

                var existingSOA = _dbContext.StatementOfAccounts
                                               .FirstOrDefault(si => si.Id == model.SOAId);

                if (existingSOA.Amount >= model.Amount)
                {
                    var generateORNo = await _receiptRepo.GenerateORNo();

                    model.SeriesNumber = getLastNumber;
                    model.ORNo = generateORNo;
                    model.CreatedBy = _userManager.GetUserName(this.User);
                    _dbContext.Add(model);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("OfficialReceiptIndex");
                }
                else
                {
                    TempData["error"] = "Please input below or exact amount based on Statment of Account";
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "The information you submitted is not valid!");
                return View(model);
            }
        }

        public async Task<IActionResult> CollectionReceipt(int id)
        {
            var cr = await _receiptRepo.FindCR(id);
            return View(cr);
        }

        public async Task<IActionResult> OfficialReceipt(int id)
        {
            var or = await _receiptRepo.FindOR(id);
            return View(or);
        }

        public async Task<IActionResult> PrintedCR(int id)
        {
            var findIdOfCR = await _receiptRepo.FindCR(id);
            if (findIdOfCR != null && !findIdOfCR.IsPrinted)
            {
                findIdOfCR.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("CollectionReceipt", new { id = id });
        }

        public async Task<IActionResult> PrintedOR(int id)
        {
            var findIdOfOR = await _receiptRepo.FindOR(id);
            if (findIdOfOR != null && !findIdOfOR.IsPrinted)
            {
                findIdOfOR.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("OfficialReceipt", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesInvoices(int customerNo)
        {
            var invoices = await _dbContext
                .SalesInvoices
                .Where(si => si.CustomerNo == customerNo && !si.IsPaid)
                .OrderBy(si => si.Id)
                .ToListAsync();

            var invoiceList = invoices.Select(si => new SelectListItem
            {
                Value = si.Id.ToString(),   // Replace with your actual ID property
                Text = si.SINo              // Replace with your actual property for display text
            }).ToList();

            return Json(invoiceList);
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoiceDetails(int invoiceNo)
        {
            var invoice = await _dbContext
                .SalesInvoices
                .FirstOrDefaultAsync(si => si.Id == invoiceNo);

            if (invoice != null)
            {
                return Json(new
                {
                    Amount = invoice.NetDiscount.ToString("0.00"),
                    AmountPaid = invoice.AmountPaid.ToString("0.00"),
                    Balance = invoice.Balance.ToString("0.00"),
                    Ewt = invoice.WithHoldingTaxAmount.ToString("0.00"),
                    Wvat = invoice.WithHoldingVatAmount.ToString("0.00"),
                    Total = (invoice.NetDiscount - (invoice.WithHoldingTaxAmount + invoice.WithHoldingVatAmount)).ToString("0.00")
                });
            }
            return Json(null);
        }
    }
}