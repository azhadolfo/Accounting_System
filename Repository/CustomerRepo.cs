﻿using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Repository
{
    public class CustomerRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _dbContext
                .Customers
                .ToListAsync();
        }

        public async Task<Customer> FindCustomerAsync(int? id)
        {
            var customer = await _dbContext
                .Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }

        public bool CustomerExist(int id)
        {
            return _dbContext.Customers.Any(c => c.Id == id);
        }
    }
}