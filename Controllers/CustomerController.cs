using Accounting_System.Data;
using Accounting_System.Models;
using Accounting_System.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accounting_System.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly CustomerRepo _customerRepo;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SalesOrderRepo _salesOrderRepo;

        public CustomerController(ApplicationDbContext dbContext, CustomerRepo customerRepo, UserManager<IdentityUser> userManager, SalesOrderRepo salesOrderRepo)
        {
            _dbContext = dbContext;
            _customerRepo = customerRepo;
            this._userManager = userManager;
            _salesOrderRepo = salesOrderRepo;
        }

        public async Task<IActionResult> Index()
        {
            var customer = await _customerRepo.GetCustomersAsync();

            return View(customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {

                customer.CreatedBy = _userManager.GetUserName(this.User);
                _dbContext.Add(customer);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "The information you submitted is not valid!");
                return View(customer);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.FindCustomerAsync(id);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            var existingModel = await _customerRepo.FindCustomerAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    existingModel.Name = customer.Name;
                    existingModel.Address = customer.Address;
                    existingModel.TinNo = customer.TinNo;
                    existingModel.BusinessStyle = customer.BusinessStyle;
                    existingModel.Terms = customer.Terms;
                    existingModel.CustomerType = customer.CustomerType;
                    existingModel.WithHoldingTax = customer.WithHoldingTax;
                    existingModel.WithHoldingVat = customer.WithHoldingVat;

                    _dbContext.Update(existingModel);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_customerRepo.CustomerExist(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.FindCustomerAsync(id);

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dbContext.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }

            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.FindCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public async Task<IActionResult> OrderSlip()
        {
            var salesOrder = await _salesOrderRepo.GetSalesOrderAsync();

            return View(salesOrder);
        }

        [HttpGet]
        public IActionResult CreateCOS()
        {
            var viewModel = new SalesOrder();
            viewModel.Customers = _dbContext.Customers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCOS(SalesOrder model)
        {
           
            if (ModelState.IsValid)
            {
                var generateCosNo = await _salesOrderRepo.GenerateCOSNo();
                
                
                model.COSNo = generateCosNo;
                model.Status = "Pending";
                model.Balance = model.Quantity;
                if (model.QuantityServe != 0)
                {
                    model.Balance = model.Quantity - model.QuantityServe;
                }
                model.CreatedBy = _userManager.GetUserName(this.User);
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Sales Order created successfully";
                return RedirectToAction("OrderSlip");  
            }
            else {
                    ModelState.AddModelError("", "The information you submitted is not valid!");
                    return View(model);
                }
            }

        public IActionResult PrintOrderSlip()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditOrderSlip(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _salesOrderRepo.FindSalesOrderAsync(id);
            salesOrder.Customers = _dbContext.Customers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();

            return View(salesOrder);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrderSlip(int id, SalesOrder salesOrder)
        {
            if (id != salesOrder.Id)
            {
                return NotFound();
            }
            var existingModel = await _salesOrderRepo.FindSalesOrderAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    existingModel.CustomerId = salesOrder.CustomerId;
                    existingModel.PO = salesOrder.PO;
                    existingModel.Quantity = salesOrder.Quantity;
                    existingModel.OrderAmount = salesOrder.OrderAmount;
                    existingModel.DeliveryDate = salesOrder.DeliveryDate;
                    existingModel.TransactionDate = salesOrder.TransactionDate;
                    existingModel.Remarks = salesOrder.Remarks;

                    _dbContext.Update(existingModel);
                    TempData["success"] = "Sales Order updated successfully";
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction(nameof(OrderSlip));
            }
            return View(salesOrder);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSalesOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _salesOrderRepo.FindSalesOrderAsync(id);

            return View(order);
        }

        [HttpPost, ActionName("DeleteSalesOrder")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (_dbContext.SalesOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }

            var order = await _dbContext.SalesOrders.FindAsync(id);
            if (order != null)
            {
                _dbContext.SalesOrders.Remove(order);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(OrderSlip));
        }
    }
}