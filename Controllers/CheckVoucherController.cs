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
            var viewModel = new CheckVoucherHeader();
            viewModel.RR = _dbContext.ReceivingReports
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.RRNo
                })
                .ToList();

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CheckVoucherHeader model)
        {
            model.RR = _dbContext.ReceivingReports
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.RRNo
                })
                .ToList();

            if (ModelState.IsValid)
            {
                var existingReceivingReport = _dbContext.ReceivingReports
                                               .FirstOrDefault(si => si.Id == model.RRId);

                    var generateCVNo = await _checkVoucherRepo.GenerateCVNo();
                    model.SeriesNumber = await _checkVoucherRepo.GetLastSeriesNumberCV();
                    model.CVNo = generateCVNo;
                    model.CreatedBy = _userManager.GetUserName(this.User);
                    _dbContext.Add(model);
                    await _dbContext.SaveChangesAsync();
                    TempData["success"] = "Check Voucher created successfully";
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