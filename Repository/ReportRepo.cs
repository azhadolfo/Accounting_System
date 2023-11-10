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
    }
}