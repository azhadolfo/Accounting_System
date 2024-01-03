using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class CheckVoucherController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly CheckVoucherRepo _checkVoucherRepo;

        public CheckVoucherController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, CheckVoucherRepo checkVoucherRepo)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _checkVoucherRepo = checkVoucherRepo;
        }

        public async Task<IActionResult> Index()
        {
            var cv = await _checkVoucherRepo.GetCheckVouchers();

            return View(cv);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CheckVoucherVM
            {
                Header = new CheckVoucherHeader(),
                Details = new CheckVoucherDetail()
            };

            viewModel.Header.RR = _dbContext.ReceivingReports
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.RRNo
                })
                .ToList();

            viewModel.Details.COA = _dbContext.ChartOfAccounts
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Number + " " + s.Name
                })
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckVoucherVM model)
        {
            model.Header.RR = _dbContext.ReceivingReports
               .Select(rr => new SelectListItem
               {
                   Value = rr.Id.ToString(),
                   Text = rr.RRNo
               })
               .ToList();

            model.Details.COA = _dbContext.ChartOfAccounts
                .Select(coa => new SelectListItem
                {
                    Value = coa.Id.ToString(),
                    Text = coa.Number + " " + coa.Name
                })
                .ToList();

            if (ModelState.IsValid)
            {
                var getLastNumber = await _checkVoucherRepo.GetLastSeriesNumberCV();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reached the maximum Series Number";
                    return View(model);
                }

                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Check Voucher created successfully, Warning {totalRemainingSeries} series numbers remaining";
                }
                else
                {
                    TempData["success"] = "Check Voucher created successfully";
                }

                //CV Header Entry
                var generateCVNo = await _checkVoucherRepo.GenerateCVNo();
                
                model.Header.SeriesNumber = getLastNumber;
                model.Header.CVNo = generateCVNo;
                model.Header.CreatedBy = _userManager.GetUserName(this.User);

                //CV Details Entry
                model.Details.CreatedBy = _userManager.GetUserName(this.User);


                _dbContext.Add(model.Header);  // Add CheckVoucherHeader to the context
                _dbContext.Add(model.Details); // Add CheckVoucherDetails to the context

                await _dbContext.SaveChangesAsync();  // await the SaveChangesAsync method
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "The information you submitted is not valid!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Print()
        {
            return View();
        }

        public async Task<IActionResult> Printed(int id)
        {
            var cv = await _dbContext.CheckVoucherHeaders.FindAsync(id);
            if (cv != null && !cv.IsPrinted)
            {
                cv.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Print", new { id = id });
        }

        public async Task<IActionResult> Post(int cvId)
        {
            var model = await _dbContext.CheckVoucherHeaders.FindAsync(cvId);

            if (model != null)
            {
                if (!model.IsPosted)
                {
                    model.IsPosted = true;

                    await _dbContext.SaveChangesAsync();
                    TempData["success"] = "Check Voucher has been Posted.";

                }
                //else
                //{
                //    model.IsVoid = true;
                //    await _dbContext.SaveChangesAsync();
                //    TempData["success"] = "Purchase Order has been Voided.";
                //}
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id, CheckVoucherVM model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existingHeaderModel = await _dbContext.CheckVoucherHeaders.FindAsync(id);
            var existingDetailsModel = await _dbContext.CheckVoucherDetails.FindAsync(id);

            if (existingHeaderModel == null || existingDetailsModel == null)
            {
                return NotFound();
            }

            existingHeaderModel.RR = _dbContext.ReceivingReports
                .Select(rr => new SelectListItem
                {
                    Value = rr.Id.ToString(),
                    Text = rr.RRNo
                })
                .ToList();

            existingDetailsModel.COA = _dbContext.ChartOfAccounts
                .Select(coa => new SelectListItem
                {
                    Value = coa.Id.ToString(),
                    Text = coa.Number + " " + coa.Name
                })
                .ToList();

            model.Header = existingHeaderModel; // Assign the updated header model to the view model
            model.Details = existingDetailsModel; // Assign the updated details model to the view model

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CheckVoucherVM model)
        {
            model.Header.RR = _dbContext.ReceivingReports
               .Select(rr => new SelectListItem
               {
                   Value = rr.Id.ToString(),
                   Text = rr.RRNo
               })
               .ToList();

            model.Details.COA = _dbContext.ChartOfAccounts
                .Select(coa => new SelectListItem
                {
                    Value = coa.Id.ToString(),
                    Text = coa.Number + " " + coa.Name
                })
                .ToList();

            

            if (ModelState.IsValid)
            {
                var getLastNumber = await _checkVoucherRepo.GetLastSeriesNumberCV(); 
                
                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reached the maximum Series Number";
                    return View(model);
                }

                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Check Voucher created successfully, Warning {totalRemainingSeries} series numbers remaining";
                }
                else
                {
                    TempData["success"] = "Check Voucher created successfully";
                }

                var existingHeaderModel = await _dbContext.CheckVoucherHeaders.FindAsync(model.Header.Id);
                var existingDetailsModel = await _dbContext.CheckVoucherDetails.FindAsync(model.Details.Id);

                if (existingHeaderModel == null)
                {
                    return NotFound();
                }
                if (existingDetailsModel == null)
                {
                    return NotFound();
                }

                //CV Header Entry
                var generateCVNo = await _checkVoucherRepo.GenerateCVNo();
                
                existingHeaderModel.SeriesNumber = model.Header.SeriesNumber;
                existingHeaderModel.CVNo = model.Header.CVNo;
                existingHeaderModel.CreatedBy = model.Header.CreatedBy;

                //CV Details Entry
                existingDetailsModel.CreatedBy = model.Details.CreatedBy;

                await _dbContext.SaveChangesAsync();  // await the SaveChangesAsync method
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "The information you submitted is not valid!";
                return View(model);
            }
        }
    }
}