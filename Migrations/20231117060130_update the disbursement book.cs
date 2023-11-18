using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class updatethedisbursementbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChartOfAccount",
                table: "DisbursementBooks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "DisbursementBooks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Debit",
                table: "DisbursementBooks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChartOfAccount",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "DisbursementBooks");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "DisbursementBooks");
        }
    }
}
