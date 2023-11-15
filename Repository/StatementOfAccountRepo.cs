﻿using Accounting_System.Data;
using Accounting_System.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Accounting_System.Repository
{
    public class StatementOfAccountRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public StatementOfAccountRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StatementOfAccount>> GetSOAListAsync()
        {
            return await _dbContext
                .StatementOfAccounts
                .Include(s => s.Customer)
                .ToListAsync();
        }

        public async Task<int> GetLastSOA()
        {
            var lastRow = await _dbContext
                .StatementOfAccounts
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();

            if (lastRow != null)
            {
                // Increment the last serial by one and return it
                return lastRow.Number + 1;
            }
            else
            {
                // If there are no existing records, you can start with a default value like 1
                return 1;
            }
        }

        public async Task<StatementOfAccount> FindSOA(int id)
        {
            var statementOfAccount = await _dbContext
                .StatementOfAccounts
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (statementOfAccount != null)
            {
                return statementOfAccount;
            }
            else
            {
                throw new ArgumentException("Invalid id value. The id must be greater than 0.");
            }
        }
    }
}