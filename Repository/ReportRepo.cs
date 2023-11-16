using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class ReportRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ReportRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SalesInvoice>> GetSalesBooksAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var salesBooks = _dbContext
             .SalesInvoices
             .AsEnumerable()
             .Where(s => DateTime.Parse(s.TransactionDate) >= fromDate && DateTime.Parse(s.TransactionDate) <= toDate && s.IsPosted)
             .OrderBy(s => s.Id)
             .ToList();

            return salesBooks;
        }

        public async Task<List<CashReceiptBook>> GetCashReceiptBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var cashReceiptBooks = _dbContext
             .CashReceiptBooks
             .AsEnumerable()
             .Where(cr => DateTime.Parse(cr.ORDate) >= fromDate && DateTime.Parse(cr.ORDate) <= toDate)
             .OrderBy(s => s.Id)
             .ToList();

            return cashReceiptBooks;
        }

        public async Task<List<PurchaseOrder>> GetPurchaseBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var cashReceiptBooks = _dbContext
             .PurchaseOrders
             .AsEnumerable()
             .Where(p => DateTime.Parse(p.Date) >= fromDate && DateTime.Parse(p.Date) <= toDate)
             .OrderBy(s => s.Id)
             .ToList();

            return cashReceiptBooks;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dbContext
                .Customers
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext
                .Products
                .ToListAsync();
        }
    }
}