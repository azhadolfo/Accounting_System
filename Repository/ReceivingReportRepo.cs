using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class ReceivingReportRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceivingReportRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> GetLastSeriesNumber()
        {
            var lastInvoice = await _dbContext
                .ReceivingReports
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

        public async Task<string> GenerateRRNo()
        {
            var receivingReport = await _dbContext
                .ReceivingReports
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (receivingReport != null)
            {
                var generatedRR = receivingReport.SeriesNumber + 1;
                return $"RR{generatedRR.ToString("D10")}";
            }
            else
            {
                return $"RR{1.ToString("D10")}";
            }
        }

        public async Task<string> GetPONoAsync(int id)
        {
            if (id != 0)
            {
                var po = await _dbContext
                                .PurchaseOrders
                                .FirstOrDefaultAsync(po => po.Id == id);
                return po.PONo;
            }
            else
            {
                throw new ArgumentException("No record found in supplier.");
            }
        }
    }
}