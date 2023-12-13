using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class addnewfieldstoidentitytheAccountsPayable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PONo",
                table: "ReceivingReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierNo",
                table: "PurchaseOrders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SINo",
                table: "CreditMemos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SOANo",
                table: "CreditMemos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PONo",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "SupplierNo",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "SINo",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "SOANo",
                table: "CreditMemos");
        }
    }
}
