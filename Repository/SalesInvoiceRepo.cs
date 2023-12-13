using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class SalesInvoiceRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public SalesInvoiceRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SalesInvoice>> GetSalesInvoicesAsync()
        {
            return await _dbContext
                .SalesInvoices
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<long> GetLastSeriesNumber()
        {
            var lastInvoice = await _dbContext
                .SalesInvoices
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (lastInvoice != null)
            {
                // Increment the last serial by one and return it
                return lastInvoice.SeriesNumber + 1;
            }
            else
            {
                // If there are no existing records, you can start with a default value like 1
                return 1;
            }
        }

        public async Task<string> GenerateSINo()
        {
            var salesInvoice = await _dbContext
                .SalesInvoices
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (salesInvoice != null)
            {
                var generatedSI = salesInvoice.SeriesNumber + 1;
                return $"SI{generatedSI.ToString("D10")}";
            }
            else
            {
                return $"SI{1.ToString("D10")}";
            }
        }

        public async Task<SalesInvoice> FindSalesInvoice(int id)
        {
            var invoice = await _dbContext
                .SalesInvoices
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(invoice => invoice.Id == id);

            if (invoice != null)
            {
                return invoice;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }
    }
}