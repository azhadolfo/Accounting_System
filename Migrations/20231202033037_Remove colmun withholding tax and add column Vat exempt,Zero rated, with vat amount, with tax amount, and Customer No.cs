using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class RemovecolmunwithholdingtaxandaddcolumnVatexemptZeroratedwithvatamountwithtaxamountandCustomerNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithHoldingTax",
                table: "SalesInvoices");

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerNo",
                table: "SalesInvoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VatExempt",
                table: "SalesInvoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WithHoldingTaxAmount",
                table: "SalesInvoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WithHoldingVatAmount",
                table: "SalesInvoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ZeroRated",
                table: "SalesInvoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNo",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "VatExempt",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "WithHoldingTaxAmount",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "WithHoldingVatAmount",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "ZeroRated",
                table: "SalesInvoices");

            migrationBuilder.AddColumn<bool>(
                name: "WithHoldingTax",
                table: "SalesInvoices",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
