using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly PurchaseOrderRepo _purchaseOrderRepo;

        private readonly UserManager<IdentityUser> _userManager;

        public PurchaseOrderController(ApplicationDbContext dbContext, PurchaseOrderRepo purchaseOrderRepo, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _purchaseOrderRepo = purchaseOrderRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var purchaseOrder = await _purchaseOrderRepo.GetPurchaseOrderAsync();

            return View(purchaseOrder);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new PurchaseOrder();
            viewModel.Suppliers = await _dbContext.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder model)
        {
            model.Suppliers = await _dbContext.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();
            if (ModelState.IsValid)
            {
                var getLastNumber = await _purchaseOrderRepo.GetLastSeriesNumber();

                if (getLastNumber > 9999999999)
                {
                    TempData["error"] = "You reach the maximum Series Number";
                    return View(model);
                }
                var totalRemainingSeries = 9999999999 - getLastNumber;
                if (getLastNumber >= 9999999899)
                {
                    TempData["warning"] = $"Purchase Order created successfully, Warning {totalRemainingSeries} series number remaining";
                }
                else
                {
                    TempData["success"] = "Purchase Order created successfully";
                }

                var generatedPO = await _purchaseOrderRepo.GeneratePONo();
                

                model.SeriesNumber = getLastNumber;
                model.PONo = generatedPO;
                model.CreatedBy = _userManager.GetUserName(this.User);
                model.Amount = model.Quantity * model.Price;
                model.SupplierNo = await _purchaseOrderRepo.GetSupplierNoAsync(model.SupplierId);

                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "The information you submitted is not valid!");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbContext.PurchaseOrders == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _dbContext.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            purchaseOrder.Suppliers = await _dbContext.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();

            return View(purchaseOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PurchaseOrder model)
        {
            if (ModelState.IsValid)
            {
                var existingModel = await _dbContext.PurchaseOrders.FindAsync(model.Id);

                if (existingModel == null)
                {
                    return NotFound();
                }

                model.Suppliers = await _dbContext.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();

                existingModel.Date = model.Date;
                existingModel.SupplierId = model.SupplierId;
                existingModel.ProductName = model.ProductName;
                existingModel.Quantity = model.Quantity;
                existingModel.Quantity = model.Quantity;
                existingModel.Price = model.Price;
                existingModel.Amount = model.Quantity * model.Price;
                existingModel.Remarks = model.Remarks;

                await _dbContext.SaveChangesAsync();

                TempData["success"] = "Purchase Order updated successfully";
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

            var purchaseOrder = await _dbContext.PurchaseOrders
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        public async Task<IActionResult> Printed(int id)
        {
            var po = await _dbContext.PurchaseOrders.FindAsync(id);
            if (po != null && !po.IsPrinted)
            {
                po.IsPrinted = true;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Print", new { id = id });
        }

        public async Task<IActionResult> Post(int poId)
        {
            var model = await _dbContext.PurchaseOrders.FindAsync(poId);

            if (model != null)
            {
                if (!model.IsPosted)
                {
                    model.IsPosted = true;

                    await _dbContext.SaveChangesAsync();
                    TempData["success"] = "Purchase Order has been Posted.";

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
    }
}