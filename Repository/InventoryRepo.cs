using Accounting_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class InventoryRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateQuantity(decimal sold, int productId)
        {
            var inventory = await _dbContext
                .Inventories
                .FirstOrDefaultAsync(x => x.ProductId == productId);
            if (inventory == null)
            {
                throw new ArgumentException("No product found !");
            }
            inventory.QuantityServe += sold;
            inventory.QuantityBalance -= sold;

            await _dbContext.SaveChangesAsync();
        }
    }
}