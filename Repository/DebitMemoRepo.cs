using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class DebitMemoRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public DebitMemoRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<DebitMemo>> GetDMAsync()
        {
            return await _dbContext
                .DebitMemos
                .OrderByDescending(d => d.Id)
                .ToListAsync();
        }

        public async Task<long> GetLastSeriesNumber()
        {
            var lastInvoice = await _dbContext
                .DebitMemos
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

        public async Task<string> GenerateDMNo()
        {
            var debitMemo = await _dbContext
                .DebitMemos
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (debitMemo != null)
            {
                var generatedCR = debitMemo.SeriesNumber + 1;
                return $"DM{generatedCR.ToString("D10")}";
            }
            else
            {
                return $"DM{1.ToString("D10")}";
            }
        }

        public async Task<DebitMemo> FindDM(int id)
        {
            var debitMemo = await _dbContext
                .DebitMemos
                .Include(s => s.SalesInvoice)
                .FirstOrDefaultAsync(debitMemo => debitMemo.Id == id);

            if (debitMemo != null)
            {
                return debitMemo;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }
    }
}