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

        public async Task<List<CollectionReceipt>> GetCollectionReceiptBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var crBook = _dbContext
             .CollectionReceipts
             .Include(c => c.SalesInvoice)
             .AsEnumerable()
             .Where(s => DateTime.Parse(s.Date) >= fromDate && DateTime.Parse(s.Date) <= toDate)
             .OrderBy(s => s.Id)
             .ToList();

            return crBook;
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