using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (ModelState.IsValid)
            {
                var generateCVNo = await _checkVoucherRepo.GenerateCVNo();
                long getLastNumber = await _checkVoucherRepo.GetLastSeriesNumberCV();
                model.Header.SeriesNumber = getLastNumber;
                model.Header.CVNo = generateCVNo;
                model.Header.CreatedBy = _userManager.GetUserName(this.User);

                var headerEntity = new CheckVoucherHeader
                {
                    CVNo = model.Header.CVNo,
                    CreatedBy = model.Header.CreatedBy,
                    // Map other properties...
                };

                var detailsEntity = new CheckVoucherDetail
                {
                    COA = model.Details.COA,
                    // Map other properties...
                };

                _dbContext.Add(headerEntity);  // Add CheckVoucherHeader to the context
                _dbContext.Add(detailsEntity); // Add CheckVoucherDetails to the context

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }

                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = "Check Voucher created successfully, Warning 100 series number remaining";
                }
                else
                {
                    TempData["success"] = "Check Voucher created successfully";
                }

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "The information you submitted is not valid!";
                return View(model);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CheckVoucherVM model)
        //{
        //    model.Header.RR = _dbContext.ReceivingReports
        //        .Select(s => new SelectListItem
        //        {
        //            Value = s.Id.ToString(),
        //            Text = s.RRNo
        //        })
        //        .ToList();

        //    model.Details.COA = _dbContext.ChartOfAccounts
        //        .Select(s => new SelectListItem
        //        {
        //            Value = s.Id.ToString(),
        //            Text = s.Number + " " + s.Name
        //        })
        //        .ToList();

        //    //if (ModelState.IsValid)
        //    //{
        //            var generateCVNo = await _checkVoucherRepo.GenerateCVNo();
        //            model.Header.SeriesNumber = await _checkVoucherRepo.GetLastSeriesNumberCV();
        //            model.Header.CVNo = generateCVNo;
        //            model.Header.CreatedBy = _userManager.GetUserName(this.User);

        //            _dbContext.Add(model);
        //            await _dbContext.SaveChangesAsync();
        //            TempData["success"] = "Check Voucher created successfully";
        //            return RedirectToAction("Index");
        //    //}
        //    //else
        //    //{
        //    //    TempData["error"] = "The information you submitted is not valid!";
        //    //    return View(model);
        //    //}
        //}
    }
}