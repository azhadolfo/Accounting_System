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

        public async Task<List<SalesBook>> GetSalesBooksAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var salesBooks = _dbContext
             .SalesBooks
             .AsEnumerable()
             .Where(s => DateTime.Parse(s.TransactionDate) >= fromDate && DateTime.Parse(s.TransactionDate) <= toDate)
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
             .Where(cr => DateTime.Parse(cr.Date) >= fromDate && DateTime.Parse(cr.Date) <= toDate)
             .OrderBy(s => s.Id)
             .ToList();

            return cashReceiptBooks;
        }

        public async Task<List<PurchaseJournalBook>> GetPurchaseBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var cashReceiptBooks = _dbContext
             .PurchaseJournalBooks
             .AsEnumerable()
             .Where(p => DateTime.Parse(p.Date) >= fromDate && DateTime.Parse(p.Date) <= toDate)
             .OrderBy(s => s.Id)
             .ToList();

            return cashReceiptBooks;
        }

        public async Task<List<InventoryBook>> GetInventoryBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var inventoryBooks = _dbContext
             .InventoryBooks
             .AsEnumerable()
             .Where(i => DateTime.Parse(i.Date) >= fromDate && DateTime.Parse(i.Date) <= toDate)
             .OrderBy(i => i.Id)
             .ToList();

            return inventoryBooks;
        }

        public async Task<List<GeneralLedgerBook>> GetGeneralLedgerBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var generalLedgerBooks = _dbContext
             .GeneralLedgerBooks
             .AsEnumerable()
             .Where(i => DateTime.Parse(i.Date) >= fromDate && DateTime.Parse(i.Date) <= toDate)
             .OrderBy(i => i.Id)
             .ToList();

            return generalLedgerBooks;
        }

        public async Task<List<DisbursementBook>> GetDisbursementBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var disbursementBooks = _dbContext
             .DisbursementBooks
             .AsEnumerable()
             .Where(d => DateTime.Parse(d.Date) >= fromDate && DateTime.Parse(d.Date) <= toDate)
             .OrderBy(d => d.Id)
             .ToList();

            return disbursementBooks;
        }

        public async Task<List<JournalBook>> GetJournalBookAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var disbursementBooks = _dbContext
             .JournalBooks
             .AsEnumerable()
             .Where(d => DateTime.Parse(d.Date) >= fromDate && DateTime.Parse(d.Date) <= toDate)
             .OrderBy(d => d.Id)
             .ToList();

            return disbursementBooks;
        }

        public async Task<List<AuditTrail>> GetAuditTrailAsync(string dateFrom, string dateTo)
        {
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date From must be greater than Date To !");
            }

            var auditTrail = _dbContext
             .AuditTrails
             .AsEnumerable()
             .Where(d => d.Date >= fromDate && d.Date <= toDate)
             .OrderBy(d => d.Date)
             .ToList();

            return auditTrail;
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