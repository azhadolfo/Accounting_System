using Accounting_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class CreditMemoRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public CreditMemoRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> GetLastSeriesNumber()
        {
            var lastInvoice = await _dbContext
                .CreditMemos
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

        public async Task<string> GenerateCMNo()
        {
            var creditMemo = await _dbContext
                .CreditMemos
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (creditMemo != null)
            {
                var generatedCM = creditMemo.SeriesNumber + 1;
                return $"CM{generatedCM.ToString("D10")}";
            }
            else
            {
                return $"CM{1.ToString("D10")}";
            }
        }


        public async Task<string> GetSINoAsync(int? id)
        {
            if (id != 0)
            {
                var si = await _dbContext
                                .SalesInvoices
                                .FirstOrDefaultAsync(po => po.Id == id);
                return si.SINo;
            }
            else
            {
                throw new ArgumentException("No record found in supplier.");
            }
        }

        public async Task<string> GetSOANoAsync(int? id)
        {
            if (id != 0)
            {
                var soa = await _dbContext
                                .StatementOfAccounts
                                .FirstOrDefaultAsync(po => po.Id == id);
                return soa.SOANo;
            }
            else
            {
                throw new ArgumentException("No record found in supplier.");
            }
        }
    }
}