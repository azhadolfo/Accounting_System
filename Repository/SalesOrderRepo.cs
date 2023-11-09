﻿using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class SalesOrderRepo
    {
        private readonly ApplicationDbContext _dbContext;
        public SalesOrderRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SalesOrder>> GetSalesOrderAsync()
        {
            return await _dbContext
                .SalesOrders
                .OrderByDescending(s => s.Id)
                .ToListAsync();
        }

        public async Task<SalesOrder> FindSalesOrderAsync(int? id)
        {
            var salesOrder = await _dbContext
                .SalesOrders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (salesOrder != null)
            {
                return salesOrder;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }
    }
}
