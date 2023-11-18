using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class Updatetableforofficialreceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SOAAmount",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "SOADate",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "SOANo",
                table: "OfficialReceipts");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialReceipts_SOAId",
                table: "OfficialReceipts",
                column: "SOAId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialReceipts_StatementOfAccounts_SOAId",
                table: "OfficialReceipts",
                column: "SOAId",
                principalTable: "StatementOfAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficialReceipts_StatementOfAccounts_SOAId",
                table: "OfficialReceipts");

            migrationBuilder.DropIndex(
                name: "IX_OfficialReceipts_SOAId",
                table: "OfficialReceipts");

            migrationBuilder.AddColumn<decimal>(
                name: "SOAAmount",
                table: "OfficialReceipts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SOADate",
                table: "OfficialReceipts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SOANo",
                table: "OfficialReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
