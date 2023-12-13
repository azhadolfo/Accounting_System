using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class StatementOfAccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly StatementOfAccountRepo _statementOfAccountRepo;

        private readonly UserManager<IdentityUser> _userManager;

        public StatementOfAccountController(ApplicationDbContext dbContext, StatementOfAccountRepo statementOfAccountRepo, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _statementOfAccountRepo = statementOfAccountRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _statementOfAccountRepo
                .GetSOAListAsync();

            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new StatementOfAccount();
            viewModel.Customers = await _dbContext.Customers
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
            viewModel.Services = await _dbContext.Services
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatementOfAccount model)
        {
            model.Customers = await _dbContext.Customers
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
            model.Services = await _dbContext.Services
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
            if (ModelState.IsValid)
            {
                long getLastNumber = await _statementOfAccountRepo.GetLastSeriesNumber();
                model.SeriesNumber = getLastNumber;

                model.SOANo = await _statementOfAccountRepo.GenerateSOANo();

                model.CreatedBy = _userManager.GetUserName(this.User);

                _dbContext.Add(model);

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }

                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = "Statement of Account created successfully, Warning 100 series number remaining";
                }
                else
                {
                    TempData["success"] = "Statement of Account created successfully";
                }

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Generate(int id)
        {
            var soa = await _statementOfAccountRepo
                .FindSOA(id);

            return View(soa);
        }

        public async Task<IActionResult> PrintedSOA(int id)
        {
            var findIdOfSOA = await _statementOfAccountRepo.FindSOA(id);
            if (findIdOfSOA != null && !findIdOfSOA.IsPrinted)
            {
                findIdOfSOA.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Generate", new { id = id });
        }
    }
}