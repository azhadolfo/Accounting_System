using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class AddthedefaultfieldinBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "StatementOfAccounts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "StatementOfAccounts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "StatementOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "StatementOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "StatementOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "StatementOfAccounts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "StatementOfAccounts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "StatementOfAccounts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "StatementOfAccounts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "SalesOrders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "SalesOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "SalesOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "SalesOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "SalesOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "SalesOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "SalesOrders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "SalesOrders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "SalesOrders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "SalesOrders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "SalesInvoices",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "SalesInvoices",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "SalesInvoices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "SalesInvoices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "SalesInvoices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "SalesInvoices",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "SalesInvoices",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "SalesInvoices",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "SalesInvoices",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "ReceivingReports",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "ReceivingReports",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "ReceivingReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "ReceivingReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "ReceivingReports",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "ReceivingReports",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "ReceivingReports",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "ReceivingReports",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "PurchaseOrders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "PurchaseOrders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "PurchaseOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "PurchaseOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "PurchaseOrders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "PurchaseOrders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "PurchaseOrders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "PurchaseOrders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "OfficialReceipts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "OfficialReceipts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "OfficialReceipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "OfficialReceipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "OfficialReceipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "OfficialReceipts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "OfficialReceipts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "OfficialReceipts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "OfficialReceipts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "Ledgers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Ledgers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "DebitMemos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "DebitMemos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "DebitMemos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "DebitMemos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "DebitMemos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "DebitMemos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "DebitMemos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "DebitMemos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "DebitMemos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "CreditMemos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "CreditMemos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "CreditMemos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "CreditMemos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "CreditMemos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "CreditMemos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "CreditMemos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "CreditMemos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "CreditMemos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "CollectionReceipts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "CollectionReceipts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "CollectionReceipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "CollectionReceipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "CollectionReceipts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "CollectionReceipts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "CollectionReceipts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "CollectionReceipts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "CheckVoucherHeaders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "CheckVoucherHeaders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "CheckVoucherHeaders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "CheckVoucherHeaders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "CheckVoucherHeaders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "CheckVoucherHeaders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "CheckVoucherHeaders",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "CheckVoucherHeaders",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "StatementOfAccounts");

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
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "SalesInvoices");

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
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "PurchaseOrders");

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
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "Ledgers");

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
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "DebitMemos");

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
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "CheckVoucherHeaders");

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
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "ChartOfAccounts");

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
    }
}
