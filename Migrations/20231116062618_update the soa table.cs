using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class updatethesoatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Particular",
                table: "StatementOfAccounts");

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "StatementOfAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StatementOfAccounts_ServicesId",
                table: "StatementOfAccounts",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementOfAccounts_Services_ServicesId",
                table: "StatementOfAccounts",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementOfAccounts_Services_ServicesId",
                table: "StatementOfAccounts");

            migrationBuilder.DropIndex(
                name: "IX_StatementOfAccounts_ServicesId",
                table: "StatementOfAccounts");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "StatementOfAccounts");

            migrationBuilder.AddColumn<string>(
                name: "Particular",
                table: "StatementOfAccounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
