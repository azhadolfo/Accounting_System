using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class removetheinheritofmasterfiletobaseentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "SalesBooks");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "PurchaseJournalBooks");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Offsettings");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "JournalBooks");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "InventoryBooks");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "GeneralLedgerBooks");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "CheckVoucherDetails");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "CashReceiptBooks");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "CashReceiptBooks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Suppliers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Suppliers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "Suppliers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Services",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Services",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Services",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Services",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "Services",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Services",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "Services",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "SalesBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "SalesBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "SalesBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "SalesBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "SalesBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "SalesBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "SalesBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "SalesBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "SalesBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "SalesBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "PurchaseJournalBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "PurchaseJournalBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "PurchaseJournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "PurchaseJournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "PurchaseJournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "PurchaseJournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "PurchaseJournalBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "PurchaseJournalBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "PurchaseJournalBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "PurchaseJournalBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Products",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Products",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "Products",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Offsettings",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Offsettings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Offsettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Offsettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Offsettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "Offsettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Offsettings",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Offsettings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "Offsettings",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "Offsettings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "JournalBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "JournalBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "JournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "JournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "JournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "JournalBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "JournalBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "JournalBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "JournalBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "JournalBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "InventoryBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "InventoryBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "InventoryBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "InventoryBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "InventoryBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "InventoryBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "InventoryBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "InventoryBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "InventoryBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "InventoryBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Inventories",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Inventories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Inventories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Inventories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Inventories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "Inventories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Inventories",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Inventories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "Inventories",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "Inventories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "GeneralLedgerBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "GeneralLedgerBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "GeneralLedgerBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "GeneralLedgerBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "GeneralLedgerBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "GeneralLedgerBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "GeneralLedgerBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "GeneralLedgerBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "GeneralLedgerBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "GeneralLedgerBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "DisbursementBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "DisbursementBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "DisbursementBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "DisbursementBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "DisbursementBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "DisbursementBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "DisbursementBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "DisbursementBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "DisbursementBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "DisbursementBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Customers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Customers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "Customers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "CheckVoucherDetails",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "CheckVoucherDetails",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "CheckVoucherDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "CheckVoucherDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "CheckVoucherDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "CheckVoucherDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "CheckVoucherDetails",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "CheckVoucherDetails",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "CheckVoucherDetails",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "CheckVoucherDetails",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "CashReceiptBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "CashReceiptBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "CashReceiptBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "CashReceiptBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "CashReceiptBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "CashReceiptBooks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "CashReceiptBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "CashReceiptBooks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "CashReceiptBooks",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "CashReceiptBooks",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
