using Accounting_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class SupplierRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetLastNumber()
        {
            var lastNumber = await _dbContext
                .Suppliers
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (lastNumber != null)
            {
                return lastNumber.Number + 1;
            }
            else
            {
                return 3001;
            }
        }
    }
}