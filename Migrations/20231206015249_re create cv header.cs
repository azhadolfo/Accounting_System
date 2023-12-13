using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class recreatecvheader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CheckVoucherHeaders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AmountInWords",
                table: "CheckVoucherHeaders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RRNo",
                table: "CheckVoucherHeaders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesNumber",
                table: "CheckVoucherHeaders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "AmountInWords",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "RRNo",
                table: "CheckVoucherHeaders");

            migrationBuilder.DropColumn(
                name: "SeriesNumber",
                table: "CheckVoucherHeaders");
        }
    }
}
