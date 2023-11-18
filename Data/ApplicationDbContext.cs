using Accounting_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Accounting_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<StatementOfAccount> StatementOfAccounts { get; set; }
        public DbSet<CollectionReceipt> CollectionReceipts { get; set; }
        public DbSet<OfficialReceipt> OfficialReceipts { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Services> Services { get; set; }

        // Book Context

        public DbSet<CashReceiptBook> CashReceiptBooks { get; set; }
        public DbSet<InventoryBook> InventoryBooks { get; set; }
        public DbSet<GeneralLedgerBook> GeneralLedgerBooks { get; set; }
        public DbSet<DisbursementBook> DisbursementBooks { get; set; }
    }
}