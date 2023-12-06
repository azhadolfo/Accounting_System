using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class CheckVoucherRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public CheckVoucherRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CheckVoucherHeader>> GetCheckVouchers()
        {
            return await _dbContext
                .CheckVoucherHeaders
                .OrderByDescending(cv => cv.Id)
                .ToListAsync();
        }
        public async Task<string> GenerateCVNo()
        {
            var checkVoucher = await _dbContext
                .CheckVoucherHeaders
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (checkVoucher != null)
            {
                var generatedCV = checkVoucher.SeriesNumber + 1;
                return $"CV{generatedCV.ToString("D10")}";
            }
            else
            {
                return $"CV{1.ToString("D10")}";
            }
        }
        public async Task<int> GetLastSeriesNumberCV()
        {
            var lastNumber = await _dbContext
                .CheckVoucherHeaders
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (lastNumber != null)
            {
                // Increment the last serial by one and return it
                return lastNumber.SeriesNumber + 1;
            }
            else
            {
                // If there are no existing records, you can start with a default value like 1
                return 1;
            }
        }
    }
}