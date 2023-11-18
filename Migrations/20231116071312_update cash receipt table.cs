using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class updatecashreceipttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ORNo",
                table: "CashReceiptBooks",
                newName: "RefNo");

            migrationBuilder.RenameColumn(
                name: "ORDate",
                table: "CashReceiptBooks",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefNo",
                table: "CashReceiptBooks",
                newName: "ORNo");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "CashReceiptBooks",
                newName: "ORDate");
        }
    }
}
